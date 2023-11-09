using A2SV.ProductHubManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.DTOs
{
    public class UserDto:BaseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
