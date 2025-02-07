using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.OrderItem;
using System.Collections.Generic;

namespace E_Commerce.Application.DTOs.Order
{
    public class CreateOrderDto : BaseDto, IOrderDto
    {
        public int UserId { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
