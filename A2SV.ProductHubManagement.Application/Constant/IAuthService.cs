using A2SV.ProductHubManagement.Application.Models;
using A2SV.ProductHubManagement.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Constant
{
    public interface IAuthService
    {
        public Task<Result<RegisterResponse>> Register(RegisteModel request);

        public Task<Result<LoginResponse>> Login(LoginModel request);

    }
}
