using AutoMapper;
using E_Commerce.Application.DTOs.Order.Validators;
using E_Commerce.Application.DTOs.OrderItem.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Order.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateOrdeCommandHandler(IOrderRepository orderRepository
            ,IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrdeCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateOrderDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.CreateOrderDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var order = _mapper.Map<Domain.Order>(request.CreateOrderDto);
            await _orderRepository.Add(order);
            return order.Id;
        }
    }
}
