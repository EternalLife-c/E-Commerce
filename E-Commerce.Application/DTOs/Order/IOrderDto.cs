using E_Commerce.Application.DTOs.OrderItem;
using System;
using System.Collections.Generic;

namespace E_Commerce.Application.DTOs.Order
{
    public interface IOrderDto
    {
        public Guid UserId { get; set; }
    }
}
