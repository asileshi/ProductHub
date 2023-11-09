using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Application.Features.Products.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Product.Id);
            
            _mapper.Map(request.Product, product);
            await _productRepository.Update(product);

            return _mapper.Map<ProductDto>(product);

        }
    }
}
