using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Application.Features.Products.Requests.Commands;
using A2SV.ProductHubManagement.Application.Response;
using A2SV.ProductHubManagement.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);
            var productDto = _mapper.Map<ProductDto>(request.Product);
            await _productRepository.Add(product);
            var response = new BaseCommandResponse<ProductDto> { 
                Message = "Created sussusfully!",
                Success = true,
                Value = productDto,

            };
            return response;
        }
    }
}
