using A2SV.ProductHubManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Domain
{
    public class Product : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pricing { get; set; }
        public bool Availability { get; set; }

        // Foreign key for the product owner (User)
        public int UserId { get; set; }
        // Navigation property for many-to-one relationship with user (product owner)
        public User User { get; set; }

        // Foreign key for the category
        public int CategoryId { get; set; }
        // Navigation property for many-to-many relationship with categories
        public ICollection<Category> Categories { get; set; }

        // Collection of bookings associated with the product
        public ICollection<Booking> Bookings { get; set; }
    }


}
