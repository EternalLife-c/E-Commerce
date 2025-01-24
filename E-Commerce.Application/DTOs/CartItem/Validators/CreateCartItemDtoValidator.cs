using E_Commerce.Application.DTOs.Cart.Validators;
using E_Commerce.Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.CartItem.Validators
{
    public class CreateCartItemDtoValidator : AbstractValidator<CreateCartItemDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CreateCartItemDtoValidator(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            Include(new ICartItemDtoValidator(_cartRepository, _productRepository));
        }
    }
}
