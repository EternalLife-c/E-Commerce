using AutoMapper;
using E_Commerce.Application.DTOs.OrderItem;
using E_Commerce.Application.Features.OrderItem.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.OrderItem.Handlers.Queries
{
    public class GetOrderItemRequestHandler : IRequestHandler<GetOrderItemRequest
        , OrderItemDto>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public GetOrderItemRequestHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task<OrderItemDto> Handle(GetOrderItemRequest request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.Get(request.Id);
            return _mapper.Map<OrderItemDto>(orderItem);
        }
    }
}
