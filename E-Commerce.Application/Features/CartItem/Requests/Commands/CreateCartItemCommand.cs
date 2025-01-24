﻿using E_Commerce.Application.DTOs.CartItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.CartItem.Requests.Commands
{
    public class CreateCartItemCommand : IRequest<int>
    {
        public CreateCartItemDto CreateCartItemDto { get; set; }
    }
}
