using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Order.Requests.Commands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
