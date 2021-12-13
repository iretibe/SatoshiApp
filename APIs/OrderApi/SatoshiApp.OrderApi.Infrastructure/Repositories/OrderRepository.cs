using Microsoft.EntityFrameworkCore;
using SatoshiApp.OrderApi.Application.Contracts.Persistence;
using SatoshiApp.OrderApi.Domain.Entities;
using SatoshiApp.OrderApi.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatoshiApp.OrderApi.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orderList;
        }
    }
}
