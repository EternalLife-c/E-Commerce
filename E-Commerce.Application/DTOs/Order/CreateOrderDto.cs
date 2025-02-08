using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.OrderItem;
using System;
using System.Collections.Generic;

namespace E_Commerce.Application.DTOs.Order
{
    public class CreateOrderDto : IOrderDto
    {
        public Guid UserId { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
