using SatoshiApp.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.UI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModels>> GetProduct();
        Task<IEnumerable<ProductModels>> GetProductByName(string name);
        Task<ProductModels> GetProduct(string id);
        Task<ProductModels> CreateProduct(ProductModels model);
    }
}
