using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Cart.Requests.Commands
{
    public class DeleteCartCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
