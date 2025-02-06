using AutoMapper;
using E_Commerce.Application.DTOs.Transaction;
using E_Commerce.Application.Features.Transaction.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Transaction.Handlers.Queries
{
    public class GetTransactionsListRequestHandler : IRequestHandler<GetTransactionsListRequest
        , List<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionsListRequestHandler(ITransactionRepository transactionRepository
            , IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<List<TransactionDto>> Handle(GetTransactionsListRequest request
            , CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAll();
            return _mapper.Map<List<TransactionDto>>(transactions);
        }
    }
}
