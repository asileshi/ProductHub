using A2SV.ProductHubManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Domain
{
    public class Category:BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property for one-to-many relationship with products
    }
}
