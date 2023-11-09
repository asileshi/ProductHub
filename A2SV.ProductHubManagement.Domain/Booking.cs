using A2SV.ProductHubManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Domain
{
    public class Booking : BaseDomainEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Quantity { get; set; }

        
    }

}
