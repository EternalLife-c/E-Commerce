using E_Commerce.Application.DTOs.CartItem.Validators;
using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Commerce.Application.DTOs.Cart.Validators
{
    public class ICartItemDtoValidator : AbstractValidator<ICartDto>
    {
        private readonly IUserRepository _userRepository;

        public ICartItemDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(e => e.UserId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    var UserExists = await _userRepository.Exsits(id);
                    return !UserExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(e => e.CartItems)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");
        }
    }
}