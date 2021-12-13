using SatoshiApp.ProductApi.Entities;
using System;
using System.Linq;

namespace SatoshiApp.ProductApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }

            var produts = new Product[]
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Laptop",
                    Description = "This is a laptop.",
                    ProductImage = "product1.png",
                    Price = 1950.00M
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Keyboard",
                    Description = "This is a keyboard.",
                    ProductImage = "product2.png",
                    Price = 450.00M
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Paper",
                    Description = "Paper is a paper.",
                    ProductImage = "product3.png",
                    Price = 375.00M
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Phone",
                    Description = "Paper is a phone.",
                    ProductImage = "product4.png",
                    Price = 1450.00M
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Printer",
                    Description = "This is a printer.",
                    ProductImage = "product5.png",
                    Price = 655.00M
                }
            };
            
            foreach (Product s in produts)
            {
                context.Product.Add(s);
            }

            context.SaveChanges();
        }
    }
}
