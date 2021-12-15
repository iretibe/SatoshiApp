using AutoMapper;
using SatoshiApp.BasketApi.Entities;
using SatoshiApp.EventBus.Messages.Events;

namespace SatoshiApp.BasketApi.Mapper
{
	public class BasketProfile : Profile
	{
		public BasketProfile()
		{
			CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
		}
	}
}
