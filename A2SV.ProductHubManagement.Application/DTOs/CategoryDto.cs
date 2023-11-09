using A2SV.ProductHubManagement.Application.DTOs.Common;
using A2SV.ProductHubManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.DTOs
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
