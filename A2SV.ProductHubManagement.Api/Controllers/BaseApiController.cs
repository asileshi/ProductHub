using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A2SV.ProductHubManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Application.Response.Result<T> result)
        {
            if (result == null)
                return NotFound(result);
            else if (result.Success && result.Value != null)
                return Ok(result);
            else if (result.Success && result.Value == null)
                return NotFound(result);
            else
                return BadRequest(result);
        }

    }
}