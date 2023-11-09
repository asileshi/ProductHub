using A2SV.ProductHubManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Domain
{
    public class AuthUser: Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation property for one-to-many relationship with products
    }
}
