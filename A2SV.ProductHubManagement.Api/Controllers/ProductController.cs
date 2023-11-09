using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Application.Features.Products.Requests.Commands;
using A2SV.ProductHubManagement.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A2SV.ProductHubManagement.Api.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetProdcutListRequest()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetProdcutRequest { Product = id }));
        }

        [HttpGet("filterByAvailability")]
        public async Task<ActionResult<List<ProductDto>>> FilterByAvailability()
        {
            var request = new FilterProductByAvailabilityRequest();
            var filteredProducts = await _mediator.Send(request);

            return Ok(filteredProducts);
        }

        [HttpPost("CreateProduct")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(CreateProductCommand product)
        {
            var response = await _mediator.Send(product);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
        [HttpPut("UpdateProduct")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put([FromBody] ProductDto product)
        {
            var command = new UpdateProductCommand { Product = product };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("filterByPrice")]
        public async Task<ActionResult<ProductDto>> FilterByPrice([FromQuery] decimal price)
        {
            var command = new FilterByPricingRequest { Price = price };
           var fileteredProducts = await _mediator.Send(command);
            return Ok(fileteredProducts);
            
        }
    }
}