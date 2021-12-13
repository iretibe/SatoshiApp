using System;
using System.Linq;

namespace SatoshiApp.Customer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CustomerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Entities.Customer[]
            {
                new Entities.Customer()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Dave"
                },
                new Entities.Customer()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "George"
                },
                new Entities.Customer()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Fiona"
                },
                new Entities.Customer()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Rori"
                },
                new Entities.Customer()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Olivia"
                }
            };

            foreach (Entities.Customer s in customers)
            {
                context.Customers.Add(s);
            }

            context.SaveChanges();
        }
    }
}
