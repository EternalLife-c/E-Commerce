using AutoMapper;
using E_Commerce.Application.DTOs.CartItem;
using E_Commerce.Application.Features.CartItem.Requests.Queries;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.CartItem.Handlers.Queries
{
    public class GetCartItemsListRequestHandler : IRequestHandler<GetCartItemsListRequest
        , List<CartItemDto>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public GetCartItemsListRequestHandler(ICartItemRepository cartItemRepository
            , IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        public async Task<List<CartItemDto>> Handle(GetCartItemsListRequest request
            , CancellationToken cancellationToken)
        {
            var cartitemsList = await _cartItemRepository.GetAll();
            return _mapper.Map<List<CartItemDto>>(cartitemsList);
        }
    }
}
