using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Application.Features.Categories.Requests.Commands;
using A2SV.ProductHubManagement.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.categoryDto);
            await _categoryRepository.Add(category);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
