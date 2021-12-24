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

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductModels> CreateProduct(ProductModels model)
        {
            var response = await _client.PostAsJson($"/Catalog", model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModels>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<ProductModels>> GetProduct()
        {
            var response = await _client.GetAsync("/Product");

            return await response.ReadContentAs<List<ProductModels>>();
        }

        public async Task<ProductModels> GetProduct(string id)
        {
            var response = await _client.GetAsync($"/Product/{id}");

            return await response.ReadContentAs<ProductModels>();
        }

        public async Task<IEnumerable<ProductModels>> GetProductByName(string name)
        {
            var response = await _client.GetAsync($"/Product/GetProductByCategory/{name}");
            
            return await response.ReadContentAs<List<ProductModels>>();
        }
    }
}
