using AutoMapper;
using E_Commerce.Application.Features.CartItem.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.CartItem.Handlers.Queries
{
    public class GetCartItemRequestHandler : IRequestHandler<GetCartItemRequest, Domain.CartItem>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public GetCartItemRequestHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        public async Task<Domain.CartItem> Handle(GetCartItemRequest request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.Get(request.Id);
            return _mapper.Map<Domain.CartItem>(cartItem);
        }
    }
}