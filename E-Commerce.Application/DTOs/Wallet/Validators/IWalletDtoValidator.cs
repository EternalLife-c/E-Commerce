using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Wallet.Validators
{
    public class IWalletDtoValidator : AbstractValidator<IWalletDto>
    {
        private readonly IUserRepository _userRepository;

        public IWalletDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(e => e.UserId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    var UserExists = await _userRepository.Exsits(id);
                    return !UserExists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
