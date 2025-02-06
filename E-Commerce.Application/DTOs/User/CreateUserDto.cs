﻿using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Order;
using E_Commerce.Application.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.User
{
    public class CreateUserDto : BaseDto, IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
