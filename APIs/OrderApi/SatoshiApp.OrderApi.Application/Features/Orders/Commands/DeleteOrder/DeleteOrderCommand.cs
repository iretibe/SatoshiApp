﻿using MediatR;

namespace SatoshiApp.OrderApi.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
