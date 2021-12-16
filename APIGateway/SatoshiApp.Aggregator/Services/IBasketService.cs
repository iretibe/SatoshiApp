using SatoshiApp.Aggregator.Models;
using System.Threading.Tasks;

namespace SatoshiApp.Aggregator.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);
    }
}
