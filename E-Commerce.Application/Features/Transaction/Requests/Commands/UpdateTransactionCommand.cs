using E_Commerce.Application.DTOs.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Transaction.Requests.Commands
{
    public class UpdateTransactionCommand : IRequest<Unit>
    {
        public UpdateTransactionDto UpdateTransactionDto { get; set; }
    }
}
