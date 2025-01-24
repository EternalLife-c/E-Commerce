using AutoMapper;
using E_Commerce.Application.DTOs.Cart;
using E_Commerce.Application.Features.Cart.Requests.Commands;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Cart.Handlers.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CreateCartCommandHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = _mapper.Map<Domain.Cart>(request.CreateCartDto);
            await _cartRepository.Add(cart);
            return cart.Id;
        }
    }
}
