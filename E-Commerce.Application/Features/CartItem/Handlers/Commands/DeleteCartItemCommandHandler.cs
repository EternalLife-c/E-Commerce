using AutoMapper;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.CartItem.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.CartItem.Handlers.Commands
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, Unit>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.Get(request.Id);

            if (cartItem == null)
            {
                throw new NotFoundException(nameof(Domain.CartItem), request.Id);
            }

            await _cartItemRepository.Delete(cartItem);
            return Unit.Value;
        }
    }
}
