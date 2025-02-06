using AutoMapper;
using E_Commerce.Application.DTOs.Cart;
using E_Commerce.Application.Features.Cart.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Cart.Handlers.Queries
{
    public class GetCartRequestHandler : IRequestHandler<GetCartRequest, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartRequestHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<CartDto> Handle(GetCartRequest request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.Get(request.Id);
            return _mapper.Map<CartDto>(cart);
        }
    }
}
