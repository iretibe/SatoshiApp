using AutoMapper;
using SatoshiApp.DiscountGrpc.Entities;

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
