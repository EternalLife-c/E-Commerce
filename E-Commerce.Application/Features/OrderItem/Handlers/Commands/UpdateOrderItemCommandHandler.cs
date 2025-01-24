using AutoMapper;
using E_Commerce.Application.Features.OrderItem.Requests.Commands;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.OrderItem.Handlers.Commands
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, Unit>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public UpdateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.Get(request.UpdateOrderItemDto.Id);
            _mapper.Map(request.UpdateOrderItemDto, orderItem);
            await _orderItemRepository.Update(orderItem);
            return Unit.Value;
        }
    }
}
