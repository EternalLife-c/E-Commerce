using E_Commerce.Application.DTOs.CartItem;
using E_Commerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Cart
{
    public class UpdateCartDto : BaseDto, ICartDto
    {
        public Guid UserId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }
    }
}
