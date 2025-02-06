using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Transaction.Validators
{
    public class UpdateTransactionDtoValidator : AbstractValidator<UpdateTransactionDto>
    {
        private readonly IWalletRepository _walletRepository;

        public UpdateTransactionDtoValidator(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            Include(new ITransactionDtoValidator(_walletRepository));
        }
    }
}
