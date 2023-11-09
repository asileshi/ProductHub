using A2SV.ProductHubManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Features.Categories.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CreateCategoryDto categoryDto { get; set; }
    }
}
