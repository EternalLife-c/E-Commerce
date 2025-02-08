using E_Commerce.Application.DTOs.Order;
using E_Commerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.OrderItem
{
    public interface IOrderItemDto
    {
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
