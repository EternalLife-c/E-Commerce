using AutoMapper;
using E_Commerce.Application.DTOs.Cart;
using E_Commerce.Application.Features.Cart.Requests.Queries;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Cart.Handlers.Queries
{
    public class GetCartsListRequestHandler : IRequestHandler<GetCartsListRequest, List<CartDto>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartsListRequestHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<List<CartDto>> Handle(GetCartsListRequest request, CancellationToken cancellationToken)
        {
            var cartsList = await _cartRepository.GetAll();
            return _mapper.Map<List<CartDto>>(cartsList);
        }
    }
}
