using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Order;
using System;
using System.Collections.Generic;

namespace E_Commerce.Application.DTOs.User
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
}
