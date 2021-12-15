using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SatoshiApp.OrderApi.Application.Contracts.Infrastructure;
using SatoshiApp.OrderApi.Application.Contracts.Persistence;
using SatoshiApp.OrderApi.Application.Models;
using SatoshiApp.OrderApi.Infrastructure.Mail;
using SatoshiApp.OrderApi.Infrastructure.Persistence;
using SatoshiApp.OrderApi.Infrastructure.Repositories;

namespace SatoshiApp.OrderApi.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
