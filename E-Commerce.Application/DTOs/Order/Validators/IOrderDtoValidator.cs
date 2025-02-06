using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Order.Validators
{
    public class IOrderDtoValidator : AbstractValidator<IOrderDto>
    {
        private readonly IUserRepository _userRepository;

        public IOrderDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(e => e.UserId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    var UserExists = await _userRepository.Exsits(id);
                    return !UserExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(e => e.OrderItems)
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");
        }
    }
}