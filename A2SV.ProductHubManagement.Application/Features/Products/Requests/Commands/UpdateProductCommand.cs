using A2SV.ProductHubManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Products.Requests.Commands
{
    public class UpdateProductCommand:IRequest<ProductDto>
    {
        public ProductDto Product { get; set; } 
    }
}
