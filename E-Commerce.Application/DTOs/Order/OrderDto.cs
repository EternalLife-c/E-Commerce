using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.OrderItem;
using System;
using System.Collections.Generic;

namespace E_Commerce.Application.DTOs.Order
{
    public class OrderDto : BaseDto, IOrderDto
    {
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}