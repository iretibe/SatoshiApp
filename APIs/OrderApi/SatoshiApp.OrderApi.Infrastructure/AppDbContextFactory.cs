using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SatoshiApp.OrderApi.Infrastructure.Persistence;

namespace SatoshiApp.OrderApi.Infrastructure
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();

            optionsBuilder.UseSqlServer("Server=codelearnersoft.net;Database=SatoshiDB;User Id=sa;Password=YEso!@12;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True");

            return new OrderContext(optionsBuilder.Options);
        }
    }
}
