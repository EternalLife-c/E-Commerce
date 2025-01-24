using E_Commerce.Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Cart.Validators
{
    public class CreateCartDtoValidator : AbstractValidator<CreateCartDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateCartDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Include(new ICartItemDtoValidator(_userRepository));
        }
    }
}
