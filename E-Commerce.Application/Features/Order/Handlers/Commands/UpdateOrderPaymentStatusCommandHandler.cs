using AutoMapper;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Application.DTOs.Order.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Order.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Order.Handlers.Commands
{
    public class UpdateOrderPaymentStatusCommandHandler : IRequestHandler<UpdateOrderPaymentStatusCommand
        , Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateOrderPaymentStatusCommandHandler(IOrderRepository orderRepository
            , IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderPaymentStatusCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateOrderPaymentStatusDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateOrderPaymentStatusDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var order = await _orderRepository.Get(request.UpdateOrderPaymentStatusDto.Id);
            _mapper.Map(request.UpdateOrderPaymentStatusDto, order);
            return Unit.Value;
        }
    }
}
