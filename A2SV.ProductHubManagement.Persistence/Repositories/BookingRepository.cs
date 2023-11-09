using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace A2SV.ProductHubManagement.Persistence.Repositories
{
    public class BookingRepository:GenericRepository<Booking>,IBookingRepository
    {
        private readonly ProductManagementDbContext _dbContext;

        public BookingRepository(ProductManagementDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
