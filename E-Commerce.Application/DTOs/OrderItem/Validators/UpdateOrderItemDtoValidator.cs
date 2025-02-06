using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.OrderItem.Validators
{
    public class UpdateOrderItemDtoValidator : AbstractValidator<UpdateOrderItemDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderItemDtoValidator(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            Include(new IOrderItemDtoValidator(_productRepository, _orderRepository));
        }
    }
}