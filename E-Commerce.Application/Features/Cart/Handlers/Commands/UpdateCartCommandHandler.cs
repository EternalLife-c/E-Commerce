using AutoMapper;
using E_Commerce.Application.DTOs.Cart.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Cart.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace E_Commerce.Application.Features.Cart.Handlers.Commands
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, Unit>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateCartCommandHandler(ICartRepository cartRepository
            , IUserRepository userRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateCartDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateCartDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion

            var cart = await _cartRepository.Get(request.UpdateCartDto.Id);
            _mapper.Map(request.UpdateCartDto, cart);
            cart.TotalCartPrice = cart.CartItems.Sum(c => c.Price * c.Quantity);

            await _cartRepository.Update(cart);
            return Unit.Value;
        }
    }
}
