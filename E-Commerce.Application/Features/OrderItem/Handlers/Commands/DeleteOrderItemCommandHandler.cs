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
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, Unit>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public DeleteOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.Get(request.Id);
            await _orderItemRepository.Delete(orderItem);
            return Unit.Value;
        }
    }
}
