using SatoshiApp.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.UI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProduct();
        Task<IEnumerable<ProductModel>> GetProductByName(string name);
        Task<ProductModel> GetProduct(string id);
        Task<ProductModel> CreateProduct(ProductModel model);
    }
}
