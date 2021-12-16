using SatoshiApp.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SatoshiApp.UI.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
