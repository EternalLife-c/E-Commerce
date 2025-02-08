using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.User.Validators
{
    public class IUserDtoValidator : AbstractValidator<IUserDto>
    {
        private readonly IUserRepository _userRepository;

        public IUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(e => e.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(6, 32).WithMessage("{PropertyName} must be between 6 and 32 characters long.")
                .MustAsync(async (userName, token) =>
                {
                    var IsUnique = await _userRepository.IsUserNameUnique(userName);
                    return !IsUnique;
                }).WithMessage("{PropertyName} is already taken");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("Invalid {PropertyName} format.")
                .MustAsync(async (email, token) =>
                {
                    var IsUnique = await _userRepository.IsEmailUnique(email);
                    return !IsUnique;
                }).WithMessage("{PropertyName} is already taken");

            RuleFor(e => e.PasswordHash)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("{PropertyName} must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("{PropertyName} must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("{PropertyName} must contain at least one digit.");
        }
    }
}
