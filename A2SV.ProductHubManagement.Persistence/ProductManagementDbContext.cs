using A2SV.ProductHubManagement.Domain;
using A2SV.ProductHubManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Persistence
{
    public class ProductManagementDbContext:DbContext
    {
        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options):
            base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductManagementDbContext).Assembly);

        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entity.Entity.UpdatedAt = DateTime.Now;
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<AuthUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
