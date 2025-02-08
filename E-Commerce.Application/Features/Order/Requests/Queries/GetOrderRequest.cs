using E_Commerce.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Order.Requests.Queries
{
    public class GetOrderRequest : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
    }
}
