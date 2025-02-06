using AutoMapper;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Transaction.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Transaction.Handlers.Commands
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, Unit>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.Get(request.Id);

            if (transaction == null)
                throw new NotFoundException(nameof(Domain.Transaction), request.Id);

            await _transactionRepository.Delete(transaction);
            return Unit.Value;
        }
    }
}