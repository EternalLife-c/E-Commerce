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
    public class GetTransactionRequestHandler : IRequestHandler<GetTransactionRequest, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionRequestHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<TransactionDto> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.Get(request.Id);
            return _mapper.Map<TransactionDto>(transaction);
        }
    }
}
