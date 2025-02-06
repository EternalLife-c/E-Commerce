using AutoMapper;
using E_Commerce.Application.DTOs.Order.Validators;
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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository
            ,IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateOrderDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateOrderDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var order = await _orderRepository.Get(request.UpdateOrderDto.Id);
            _mapper.Map(request.UpdateOrderDto, order);
            return Unit.Value;
        }
    }
}
