using A2SV.ProductHubManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Persistence.Configuration.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /* public void Configure(EntityTypeBuilder<LeaveType> builder)
         {
             builder.HasData(new LeaveType
             {
                 Id = 1,
                 DefaultDays = 10,
                 Name = "Vacation"
             },

                 new LeaveType
                 {
                     Id = 2,
                     DefaultDays = 20,
                     Name = "Maternaty Leave"

                 });
         }*/
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           
        }
    }
}
