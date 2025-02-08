using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.CartItem.Requests.Queries
{
    public class GetCartItemRequest : IRequest<Domain.CartItem>
    {
        public Guid Id { get; set; }
    }
}
