using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SatoshiApp.OrderApi.Application.Contracts.Infrastructure;
using SatoshiApp.OrderApi.Application.Contracts.Persistence;
using SatoshiApp.OrderApi.Application.Models;
using SatoshiApp.OrderApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SatoshiApp.OrderApi.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            await SendMail(newOrder);

            return newOrder.Id;
        }

        private async Task SendMail(Order model)
        {
            var email = new Email()
            {
                To = "somad.yessoufou@persol.net",
                Body = $"Order was created.",
                Subject = "Order was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {model.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
