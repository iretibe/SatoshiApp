using AutoMapper;
using SatoshiApp.EventBus.Messages.Events;
using SatoshiApp.OrderApi.Application.Features.Orders.Commands.CheckoutOrder;

namespace SatoshiApp.OrderApi.Mapper
{
    public class OrderingProfile : Profile
	{
		public OrderingProfile()
		{
			CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
		}
	}
}
