using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.CartItem.Requests.Commands
{
    public class DeleteCartItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
