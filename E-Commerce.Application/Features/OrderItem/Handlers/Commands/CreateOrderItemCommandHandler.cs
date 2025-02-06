using AutoMapper;
using E_Commerce.Application.DTOs.OrderItem.Validators;
using E_Commerce.Application.DTOs.Product.Validators;
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
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, int>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderItemCommandHandler(IOrderItemRepository orderItemRepository
            ,IProductRepository productRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateOrderItemDtoValidator(_productRepository, _orderRepository);
            var validationResult = await validator.ValidateAsync(request.CreateOrderItemDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var orderItem = _mapper.Map<Domain.OrderItem>(request.CreateOrderItemDto);
            await _orderItemRepository.Add(orderItem);
            return orderItem.Id;
        }
    }
}
