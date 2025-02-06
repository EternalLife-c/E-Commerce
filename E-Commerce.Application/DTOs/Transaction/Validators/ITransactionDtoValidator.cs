using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Transaction.Validators
{
    public class ITransactionDtoValidator : AbstractValidator<ITransactionDto>
    {
        private readonly IWalletRepository _walletRepository;

        public ITransactionDtoValidator(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;

            RuleFor(e => e.Amount)
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(e => e.WalletId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    var WalletExists = await _walletRepository.Exsits(id);
                    return !WalletExists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
