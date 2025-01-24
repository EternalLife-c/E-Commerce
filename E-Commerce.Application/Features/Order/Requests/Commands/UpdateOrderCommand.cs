using E_Commerce.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Order.Requests.Commands
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public UpdateOrderDto UpdateOrderDto { get; set; }
    }
}
