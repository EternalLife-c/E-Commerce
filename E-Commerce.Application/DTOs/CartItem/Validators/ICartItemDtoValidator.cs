using E_Commerce.Application.Persistence.Contracts;
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
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(e => e.Price)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");

            RuleFor(e => e.CartId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    var cartExists = await _cartRepository.Exsits(id);
                    return !cartExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(e => e.ProductId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) =>
                {
                    var productExists = await _productRepository.Exsits(id);
                    return !productExists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}