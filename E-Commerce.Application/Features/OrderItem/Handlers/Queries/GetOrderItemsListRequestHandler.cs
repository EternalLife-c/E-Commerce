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
    public class GetOrderItemsListRequestHandler : IRequestHandler<GetOrderItemsListRequest
        , List<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public GetOrderItemsListRequestHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderItemDto>> Handle(GetOrderItemsListRequest request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetAll();
            return _mapper.Map<List<OrderItemDto>>(orderItems);
        }
    }
}
