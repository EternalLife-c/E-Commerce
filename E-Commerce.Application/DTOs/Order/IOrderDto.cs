using E_Commerce.Application.DTOs.OrderItem;
using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Order
{
    public interface IOrderDto
    {
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
