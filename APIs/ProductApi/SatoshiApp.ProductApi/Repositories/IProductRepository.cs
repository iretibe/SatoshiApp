using SatoshiApp.ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
