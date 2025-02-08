using AutoMapper;
using E_Commerce.Application.Contracts.Infrastructure;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Application.DTOs.Order.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Order.Requests.Commands;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Order.Handlers.Commands
{
    public class CreateOrdeCommandHandler : IRequestHandler<CreateOrdeCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentService _paymentService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrdeCommandHandler(IOrderRepository orderRepository
            ,IUserRepository userRepository, IPaymentService paymentService
            , IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _paymentService = paymentService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateOrdeCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateOrderDtoValidator(_userRepository, _orderRepository, _productRepository);
            var validationResult = await validator.ValidateAsync(request.CreateOrderDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var order = _mapper.Map<Domain.Order>(request.CreateOrderDto);
            order.OrderDate = DateTime.Now;
            order.TotalAmount = order.OrderItems.Sum(orderitem => orderitem.Price * orderitem.Quantity);
            order.IsPaid = false;
            order.IsDone = false;

            await _orderRepository.Add(order);
            return Unit.Value;
        }
    }
}