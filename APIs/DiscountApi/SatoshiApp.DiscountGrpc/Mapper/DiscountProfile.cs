using AutoMapper;
using SatoshiApp.DiscountGrpc.Entities;
using SatoshiApp.DiscountGrpc.Protos;

namespace SatoshiApp.DiscountGrpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
