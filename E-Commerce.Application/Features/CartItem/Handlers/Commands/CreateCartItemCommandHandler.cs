﻿using AutoMapper;
using E_Commerce.Application.DTOs.CartItem;
using E_Commerce.Application.DTOs.CartItem.Validators;
using E_Commerce.Application.DTOs.Category.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.CartItem.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.CartItem.Handlers.Commands
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, int>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateCartItemCommandHandler(ICartItemRepository cartItemRepository
            , ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateCartItemDtoValidator(_cartRepository, _productRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCartItemDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion

            var cartItem = _mapper.Map<Domain.CartItem>(request.CreateCartItemDto);
            cartItem = await _cartItemRepository.Add(cartItem);
            return cartItem.Id;
        }
    }
}