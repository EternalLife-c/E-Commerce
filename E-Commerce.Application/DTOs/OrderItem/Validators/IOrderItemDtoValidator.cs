using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.OrderItem.Validators
{
    public class IOrderItemDtoValidator : AbstractValidator<IOrderItemDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public IOrderItemDtoValidator(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            RuleFor(e => e.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(async (cartItem, quantity, cancellationToken) =>
                {
                    var product = await _productRepository.Get(cartItem.ProductId);
                    return product != null && quantity <= product.QuantityInStock;
                }).WithMessage("{PropertyName} exceeds available stock.");

            RuleFor(e => e.OrderId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty or default.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} cannot be an empty GUID.").MustAsync(async (id, token) =>
                {
                    var OrderExists = await _orderRepository.Exsits(id);
                    return !OrderExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(e => e.ProductId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty or default.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} cannot be an empty GUID.").MustAsync(async (id, token) =>
                {
                    var productExists = await _productRepository.Exsits(id);
                    return !productExists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}