using AutoMapper;
using E_Commerce.Application.DTOs.Transaction.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Transaction.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Transaction.Handlers.Commands
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Unit>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository
            , IMapper mapper,IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateTransactionDtoValidator(_walletRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateTransactionDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var transaction = await _transactionRepository.Get(request.UpdateTransactionDto.Id);
            _mapper.Map(request.UpdateTransactionDto, transaction);
            await _transactionRepository.Update(transaction);
            return Unit.Value;
        }
    }
}
