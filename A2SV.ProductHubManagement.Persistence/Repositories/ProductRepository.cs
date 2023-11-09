
using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ProductManagementDbContext _dbContext;

        public ProductRepository(ProductManagementDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> filterByAvailability()
        {
            return await _dbContext.Products
                .Where(p => p.Availability)
                .ToListAsync();
        }

        public async Task<List<Product>> filterByPrice(decimal price)
        {
            return await _dbContext.Products
                .Where(p => p.Pricing <= price)
                .ToListAsync();
        }
    }
}
