using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.User.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Include(new IUserDtoValidator(_userRepository));
        }
    }
}
