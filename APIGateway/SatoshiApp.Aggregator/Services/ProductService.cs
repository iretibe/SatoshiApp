using SatoshiApp.Aggregator.Extensions;
using SatoshiApp.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SatoshiApp.Aggregator.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
            var response = await _client.GetAsync("/api/v1/Product");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProduct(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Product/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(string category)
        {
            var response = await _client.GetAsync($"/api/v1/Product/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<ProductModel>>();
        }
    }
}
