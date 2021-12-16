﻿using SatoshiApp.Aggregator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.Aggregator.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
