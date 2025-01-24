using E_Commerce.Application.DTOs.Cart;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Cart.Requests.Queries
{
    public class GetCartRequest : IRequest<CartDto>
    {
        public int Id { get; set; }
    }
}
