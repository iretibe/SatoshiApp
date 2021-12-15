using SatoshiApp.BasketApi.Entities;
using System.Threading.Tasks;

namespace SatoshiApp.BasketApi.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
