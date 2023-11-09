using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Application.Features.Products.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Products.Handlers.Queries
{
    public class FilterProductByAvailabilityRequestHandler : IRequestHandler<FilterProductByAvailabilityRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public FilterProductByAvailabilityRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(FilterProductByAvailabilityRequest request, CancellationToken cancellationToken)
        {
            var avaialbleProdicts = await _productRepository.filterByAvailability();
            return _mapper.Map<List<ProductDto>>(avaialbleProdicts);
        }
    }
}
