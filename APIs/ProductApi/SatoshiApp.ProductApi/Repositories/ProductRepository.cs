using Microsoft.EntityFrameworkCore;
using SatoshiApp.ProductApi.Data;
using SatoshiApp.ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoshiApp.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context.Products.Where(p => p.ProductName == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);

            //Commit the transaction
            await _context.SaveChangesAsync();
        }
    }
}
