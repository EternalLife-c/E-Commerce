using AutoMapper;
using E_Commerce.Application.DTOs.CartItem;
using E_Commerce.Application.Features.CartItem.Requests.Commands;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.CartItem.Handlers.Commands
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, Unit>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository
            , IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.Get(request.UpdateCartItemDto.Id);
            _mapper.Map<CartItemDto>(cartItem);
            await _cartItemRepository.Update(cartItem);
            return Unit.Value;
        }
    }
}
