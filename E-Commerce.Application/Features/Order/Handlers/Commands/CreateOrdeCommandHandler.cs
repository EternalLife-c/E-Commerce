using AutoMapper;
using E_Commerce.Application.Features.Order.Requests.Commands;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Order.Handlers.Commands
{
    public class CreateOrdeCommandHandler : IRequestHandler<CreateOrdeCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrdeCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrdeCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Domain.Order>(request.CreateOrderDto);
            await _orderRepository.Add(order);
            return order.Id;
        }
    }
}
