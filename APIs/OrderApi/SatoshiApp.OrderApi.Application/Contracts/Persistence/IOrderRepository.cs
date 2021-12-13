using SatoshiApp.OrderApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.OrderApi.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
