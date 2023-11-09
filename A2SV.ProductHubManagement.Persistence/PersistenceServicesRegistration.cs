using A2SV.ProductHubManagement.Application.Constant;
using A2SV.ProductHubManagement.Application.Contracts.Persistence;
using A2SV.ProductHubManagement.Domain;
using A2SV.ProductHubManagement.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace A2SV.ProductHubManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection CongigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductManagementDbContext>(options =>

                options.UseSqlServer(
                    configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddIdentity<AuthUser, IdentityRole>()
                .AddEntityFrameworkStores<ProductManagementDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<UserManager<AuthUser>>();
            services.AddScoped<SignInManager<AuthUser>>();

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
     
            

            return services;
        
        }
    }
}
