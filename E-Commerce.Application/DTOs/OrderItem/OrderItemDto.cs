using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Order;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.OrderItem
{
    public class OrderItemDto : BaseDto
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}