using A2SV.ProductHubManagement.Application.Constant;
using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Application.Models;
using A2SV.ProductHubManagement.Application.Response;
using A2SV.ProductHubManagement.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace A2SV.ProductHubManagement.Persistence.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly ServerSettings _serverSettings;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<AuthUser> userManager,
                           SignInManager<AuthUser> signInManager,
                           IOptions<JwtSettings> jwtSettings,
                           IOptions<ServerSettings> serverSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serverSettings = serverSettings.Value;
            _jwtSettings = jwtSettings.Value;
        }


        public async Task<Result<LoginResponse>> Login(LoginModel request)
        {
            Result<LoginResponse> result = new Result<LoginResponse>();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add($"User with given Email({request.Email}) doesn't exist");
                return result;
            }

            var res = await _signInManager.PasswordSignInAsync(user.Email, request.Password, false, lockoutOnFailure: false);
            if (!res.Succeeded)
            {
                result.Success = false;
                result.Errors.Add($"Incorrect password");
                return result;
            }

            JwtSecurityToken token = await GenerateToken(user);

            var response = new LoginResponse()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            result.Value = response;
            return result;
        }


        private async Task<JwtSecurityToken> GenerateToken(AuthUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var Claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }.Union(userClaims)
             .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
                claims: Claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredential
            );

            return token;
        }
        public async Task<Result<RegisterResponse>> Register(RegisteModel request)
        {
            var result = new Result<RegisterResponse>();
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                result.Success = false;
                result.Errors.Add($"User with given Email({request.Email}) already exists");
                return result;
            }


            var user = new AuthUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = false
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
            {
                result.Success = false;
                foreach (var Error in createResult.Errors)
                {
                    result.Errors.Add(Error.Description);
                }
                return result;
            }

            return result;
        }

    }
}