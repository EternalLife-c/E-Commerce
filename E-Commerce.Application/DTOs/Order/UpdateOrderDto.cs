using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Enums;
using E_Commerce.Application.DTOs.OrderItem;
using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Order
{
    public class UpdateOrderDto : BaseDto, IOrderDto 
    {
        public int UserId { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
