using E_Commerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.CartItem
{
    public class UpdateCartItemDto : BaseDto, ICartItemDto
    {
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }
}
