using AutoMapper;
using SatoshiApp.OrderApi.Application.Features.Orders.Commands.CheckoutOrder;
using SatoshiApp.OrderApi.Application.Features.Orders.Commands.UpdateOrder;
using SatoshiApp.OrderApi.Application.Features.Orders.Queries.GetOrdersList;
using SatoshiApp.OrderApi.Domain.Entities;

namespace SatoshiApp.OrderApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersModel>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
