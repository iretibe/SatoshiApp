using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SatoshiApp.BasketApi.Entities;
using SatoshiApp.BasketApi.GrpcServices;
using SatoshiApp.BasketApi.Repositories;
using SatoshiApp.EventBus.Messages.Events;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SatoshiApp.BasketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService,
            IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _basketRepository.GetBasket(userName);

            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            //Consume Discount Grpc method by communicating with the discount grpc 
            //and calculating latest prices of a product into the shopping cart
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            return Ok(await _basketRepository.UpdateBasket(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);

            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout model)
        {
            //Get the existing items details in the basket with a total price
            var basket = await _basketRepository.GetBasket(model.UserName);

            if (basket == null)
            {
                return BadRequest();
            }

            //Send checkout event to rabbitmq
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(model);

            eventMessage.TotalPrice = basket.TotalPrice;

            await _publishEndpoint.Publish<BasketCheckoutEvent>(eventMessage);

            //Remove the basket
            await _basketRepository.DeleteBasket(basket.UserName);

            return Accepted();
        }
    }
}
