﻿using A2SV.ProductHubManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2SV.ProductHubManagement.Application.Contracts.Persistence
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<List<Product>> filterByAvailability();
        Task<List<Product>> filterByPrice(decimal price);

    }
}
