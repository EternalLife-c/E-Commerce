using E_Commerce.Application.DTOs.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Transaction.Requests.Queries
{
    public class GetTransactionRequest : IRequest<TransactionDto>
    {
        public int Id { get; set; }
    }
}
