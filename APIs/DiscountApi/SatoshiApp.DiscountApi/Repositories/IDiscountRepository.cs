﻿using SatoshiApp.DiscountApi.Entities;
using System.Threading.Tasks;

namespace SatoshiApp.DiscountApi.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}
