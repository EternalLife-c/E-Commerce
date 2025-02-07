using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.OrderItem;
using System.Collections.Generic;

namespace E_Commerce.Application.DTOs.Order
{
    public class UpdateOrderStatusDto : BaseDto, IOrderDto
    {
        public int UserId { get; set; }
        public bool IsDone { get; set; }
    }
}