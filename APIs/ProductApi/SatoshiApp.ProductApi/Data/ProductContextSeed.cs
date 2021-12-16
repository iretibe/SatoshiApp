using MongoDB.Driver;
using SatoshiApp.ProductApi.Entities;
using System.Collections.Generic;

namespace SatoshiApp.ProductApi.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertMany(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Laptop",
                    Summary = "This is a laptop promo.",
                    Description = "This is a laptop.",
                    ImageFile = "product1.png",
                    Price = 1950.00M
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Keyboard",
                    Summary = "This is a keyboard promo.",
                    Description = "This is a keyboard.",
                    ImageFile = "product2.png",
                    Price = 450.00M
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Paper",
                    Summary = "This is a paper promo",
                    Description = "Paper is a paper.",
                    ImageFile = "product3.png",
                    Price = 375.00M
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Phone",
                    Summary = "This is a promo phone",
                    Description = "This is a phone.",
                    ImageFile = "product4.png",
                    Price = 1450.00M
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Printer",
                    Summary = "This is a promo printer.",
                    Description = "This is a printer.",
                    ImageFile = "product5.png",
                    Price = 655.00M
                }
            };
        }
    }
}
