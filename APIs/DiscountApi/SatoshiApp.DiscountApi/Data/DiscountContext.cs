using Microsoft.EntityFrameworkCore;

namespace SatoshiApp.DiscountApi.Data
{
    public class DiscountContext : DbContext
    {
        //public virtual DbSet<Entities.Customer> Customer { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
    }
}
