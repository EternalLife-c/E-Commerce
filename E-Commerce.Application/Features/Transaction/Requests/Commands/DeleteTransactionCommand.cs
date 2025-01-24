using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Transaction.Requests.Commands
{
    public class DeleteTransactionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
