using AutoMapper;
using E_Commerce.Application.DTOs.OrderItem.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.OrderItem.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
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
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderItemCommandHandler(IOrderItemRepository orderItemRepository
            , IProductRepository productRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateOrderItemDtoValidator(_productRepository, _orderRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateOrderItemDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var orderItem = await _orderItemRepository.Get(request.UpdateOrderItemDto.Id);
            _mapper.Map(request.UpdateOrderItemDto, orderItem);
            await _orderItemRepository.Update(orderItem);
            return Unit.Value;
        }
    }
}
