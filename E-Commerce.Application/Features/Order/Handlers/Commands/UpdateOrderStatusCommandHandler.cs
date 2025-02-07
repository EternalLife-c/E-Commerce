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
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository
            ,IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateOrderStatusDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateOrderStatusDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var order = await _orderRepository.Get(request.UpdateOrderStatusDto.Id);
            _mapper.Map(request.UpdateOrderStatusDto, order);
            return Unit.Value;
        }
    }
}