using E_Commerce.Application.DTOs.OrderItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.OrderItem.Requests.Queries
{
    public class GetOrderItemRequest : IRequest<OrderItemDto>
    {
        public Guid Id { get; set; }
    }
}
