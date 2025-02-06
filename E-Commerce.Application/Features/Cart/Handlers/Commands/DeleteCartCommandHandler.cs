using AutoMapper;
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

namespace E_Commerce.Application.Features.Cart.Handlers.Commands
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Unit>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.Get(request.Id);
            if (cart == null)
            {
                throw new NotFoundException(nameof(Domain.Cart), request.Id);
            }
            await _cartRepository.Delete(cart);
            return Unit.Value;
        }
    }
}
