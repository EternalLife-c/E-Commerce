using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Order.Validators
{
    public class UpdateOrderPaymentStatusDtoValidator : AbstractValidator<UpdateOrderPaymentStatusDto>
    {
        private readonly IUserRepository _userRepository;

        public UpdateOrderPaymentStatusDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Include(new IOrderDtoValidator(_userRepository));
        }
    }
}
