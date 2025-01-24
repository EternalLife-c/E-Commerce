using AutoMapper;
using E_Commerce.Application.Features.Cart.Requests.Commands;
using E_Commerce.Application.Persistence.Contracts;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Cart.Handlers.Commands
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, Unit>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public UpdateCartCommandHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.Get(request.UpdateCartDto.Id);
            _mapper.Map(request.UpdateCartDto, cart);
            await _cartRepository.Update(cart);
            return Unit.Value;
        }
    }
}
