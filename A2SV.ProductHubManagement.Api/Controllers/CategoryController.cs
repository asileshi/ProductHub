using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Application.Features.Categories.Requests.Commands;
using A2SV.ProductHubManagement.Application.Features.Categories.Requests.Queries;
using A2SV.ProductHubManagement.Application.Features.Products.Requests.Commands;
using A2SV.ProductHubManagement.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A2SV.ProductHubManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ValuesController>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetCategoryListRequest()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetCategoryRequest { Id = id }));
        }
        [HttpPost("CreateCategory")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(CreateCategoryCommand category)
        {
            var response = await _mediator.Send(category);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("UpdateCategory")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put([FromBody] CategoryDto category)
        {
            var command = new UpdateCategoryCommand { Category = category };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
