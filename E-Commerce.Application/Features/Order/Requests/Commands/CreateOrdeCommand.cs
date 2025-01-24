using E_Commerce.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Order.Requests.Commands
{
    public class CreateOrdeCommand : IRequest<int>
    {
        public CreateOrderDto CreateOrderDto { get; set; }
    }
}
