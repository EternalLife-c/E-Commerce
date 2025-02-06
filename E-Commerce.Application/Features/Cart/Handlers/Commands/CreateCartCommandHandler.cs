using AutoMapper;
using E_Commerce.Application.DTOs.Cart;
using E_Commerce.Application.Features.Cart.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using E_Commerce.Application.DTOs.CartItem.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.DTOs.Cart.Validators;

namespace E_Commerce.Application.Features.Cart.Handlers.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateCartCommandHandler(ICartRepository cartRepository
            , IUserRepository userRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateCartDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCartDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion

            var cart = _mapper.Map<Domain.Cart>(request.CreateCartDto);
            await _cartRepository.Add(cart);
            return cart.Id;
        }
    }
}
