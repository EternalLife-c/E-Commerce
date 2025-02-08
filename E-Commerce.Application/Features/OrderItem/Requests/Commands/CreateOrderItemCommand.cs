using E_Commerce.Application.DTOs.OrderItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.OrderItem.Requests.Commands
{
    public class CreateOrderItemCommand : IRequest<Unit>
    {
        public CreateOrderItemDto CreateOrderItemDto { get; set; }
    }
}
