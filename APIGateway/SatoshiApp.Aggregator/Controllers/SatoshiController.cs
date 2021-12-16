using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SatoshiApp.Aggregator.Models;
using SatoshiApp.Aggregator.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SatoshiApp.Aggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatoshiController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public SatoshiController(IProductService productService, IBasketService basketService, IOrderService orderService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(SatoshiModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SatoshiModel>> GetShopping(string userName)
        {
            var basket = await _basketService.GetBasket(userName);

            foreach (var item in basket.Items)
            {
                var product = await _productService.GetProduct(item.ProductId);

                item.ProductName = product.ProductName;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            var orders = await _orderService.GetOrdersByUserName(userName);

            var shoppingModel = new SatoshiModel
            {
                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };

            return Ok(shoppingModel);
        }
    }
}
