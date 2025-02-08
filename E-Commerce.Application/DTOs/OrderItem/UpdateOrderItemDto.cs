using E_Commerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.OrderItem
{
    public class UpdateOrderItemDto :BaseDto , IOrderItemDto
    {
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}