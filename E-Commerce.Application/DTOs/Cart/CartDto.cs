using E_Commerce.Application.DTOs.CartItem;
using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Cart
{
    public class CartDto : BaseDto, ICartDto
    {
        public decimal TotalCartPrice { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }
    }
}