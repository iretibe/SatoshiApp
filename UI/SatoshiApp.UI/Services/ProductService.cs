using Microsoft.Extensions.Logging;
using SatoshiApp.UI.Extensions;
using SatoshiApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SatoshiApp.UI.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client, ILogger<ProductService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
            var response = await _client.GetAsync("/Product");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProduct(string id)
        {
            var response = await _client.GetAsync($"/Product/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(string category)
        {
            var response = await _client.GetAsync($"/Product/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson($"/Product", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
