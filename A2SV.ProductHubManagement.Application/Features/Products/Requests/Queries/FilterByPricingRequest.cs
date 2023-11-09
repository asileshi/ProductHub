using A2SV.ProductHubManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Products.Requests.Queries
{
    public class FilterByPricingRequest:IRequest<List<ProductDto>>
    {
        public decimal Price { get; set; }
    }
}
