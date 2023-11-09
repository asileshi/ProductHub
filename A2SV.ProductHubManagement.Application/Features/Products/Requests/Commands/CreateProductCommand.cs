using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Application.Response;
using A2SV.ProductHubManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand:IRequest<BaseCommandResponse<ProductDto>>
    {
        public  CreateProdcutDto Product { get; set; }
    }
}
