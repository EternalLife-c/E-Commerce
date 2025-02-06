﻿using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Wallet.Validators
{
    public class UpdateWalletDtoValidator: AbstractValidator<UpdateWalletDto>
    {
        private readonly IUserRepository _userRepository;

        public UpdateWalletDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Include(new IWalletDtoValidator(_userRepository));
        }
    }
}
