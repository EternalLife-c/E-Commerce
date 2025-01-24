using E_Commerce.Application.DTOs.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Cart.Requests.Commands
{
    public class CreateCartCommand : IRequest<int>
    {
        public CreateCartDto CreateCartDto { get; set; }
    }
}
