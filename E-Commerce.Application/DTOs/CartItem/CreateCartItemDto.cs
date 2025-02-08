using E_Commerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.CartItem
{
    public class CreateCartItemDto : ICartItemDto
    {
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
    }
}