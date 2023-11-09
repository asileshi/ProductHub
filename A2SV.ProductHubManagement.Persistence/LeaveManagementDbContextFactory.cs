using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace A2SV.ProductHubManagement.Persistence
{
    public class LeaveManagementDbContextFactory : IDesignTimeDbContextFactory<ProductManagementDbContext>
    {
        public ProductManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ProductManagementDbContext>();
            var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");
            builder.UseSqlServer(connectionString);
            return new ProductManagementDbContext(builder.Options);


        }
    }
}
