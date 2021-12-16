using MongoDB.Driver;
using SatoshiApp.ProductApi.Entities;

namespace SatoshiApp.ProductApi.Data
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
