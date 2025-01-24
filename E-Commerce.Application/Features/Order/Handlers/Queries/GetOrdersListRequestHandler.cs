using AutoMapper;
using E_Commerce.Application.DTOs.Order;
using E_Commerce.Application.Features.Order.Requests.Queries;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Order.Handlers.Queries
{
    public class GetOrdersListRequestHandler : IRequestHandler<GetOrdersListRequest
        , List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersListRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll();
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
