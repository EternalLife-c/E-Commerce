using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Application.DTOs.OrderItem.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Order.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderDtoValidator(IUserRepository userRepository, IOrderRepository orderRepository
            , IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            Include(new IOrderDtoValidator(_userRepository));

            RuleFor(e => e.OrderItems)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleForEach(order => order.OrderItems).SetValidator(new OrderItemDtoValidator
                (_productRepository, _orderRepository));
        }
    }
}