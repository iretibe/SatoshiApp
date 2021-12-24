using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SatoshiApp.UI.Models;
using SatoshiApp.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoshiApp.UI.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ProductModel(IProductService productService, IBasketService basketService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<ProductModels> ProductList { get; set; } = new List<ProductModels>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            var productList = await _productService.GetProduct();
            CategoryList = productList.Select(p => p.Category).Distinct();

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                ProductList = productList.Where(p => p.Category == categoryName);
                SelectedCategory = categoryName;
            }
            else
            {
                ProductList = productList;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _productService.GetProduct(productId);

            var userName = "swn";
            var basket = await _basketService.GetBasket(userName);

            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Color = "Black"
            });

            var basketUpdated = await _basketService.UpdateBasket(basket);

            return RedirectToPage("Cart");
        }
    }
}
