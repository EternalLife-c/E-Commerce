using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.CartItem.Validators
{
    public class ICartItemDtoValidator : AbstractValidator<ICartItemDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public ICartItemDtoValidator(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;

            RuleFor(e => e.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(async (cartItem, quantity, cancellationToken) =>
                {
                    var product = await _productRepository.Get(cartItem.ProductId);
                    return product != null && quantity <= product.QuantityInStock;
                }).WithMessage("{PropertyName} exceeds available stock.");

            RuleFor(e => e.CartId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty or default.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} cannot be an empty GUID.").MustAsync(async (id, token) =>
                {
                    var cartExists = await _cartRepository.Exsits(id);
                    return !cartExists;
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