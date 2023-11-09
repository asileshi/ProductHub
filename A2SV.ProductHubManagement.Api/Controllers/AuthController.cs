using A2SV.ProductHubManagement.Application.Constant;
using A2SV.ProductHubManagement.Application.Models;
using A2SV.ProductHubManagement.Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace A2SV.ProductHubManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController: BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMediator mediator, IMapper mapper)
        {
            _authService = authService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel request)
        {
            var responce = await _authService.Login(request);
            return HandleResult(responce);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Result<RegisteModel>>> Register([FromBody] RegisteModel registerRequest)
        {
            var response = await _authService.Register(registerRequest);

            if (!response.Success || response.Value == null)
                return HandleResult(response);
            response.Success = true;
            return HandleResult(response);

        }
    }
}
