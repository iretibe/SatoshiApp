using SatoshiApp.OrderApi.Application.Models;
using System.Threading.Tasks;

namespace SatoshiApp.OrderApi.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
