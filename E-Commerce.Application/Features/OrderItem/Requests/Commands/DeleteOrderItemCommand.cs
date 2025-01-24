using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.OrderItem.Requests.Commands
{
    public class DeleteOrderItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
