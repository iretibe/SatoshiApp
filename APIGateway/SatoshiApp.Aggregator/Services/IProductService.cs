using SatoshiApp.Aggregator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.Aggregator.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProduct();
        Task<IEnumerable<ProductModel>> GetProductByCategory(string category);
        Task<ProductModel> GetProduct(string id);
    }
}
