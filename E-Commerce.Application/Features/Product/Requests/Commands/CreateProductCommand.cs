using E_Commerce.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
namespace E_Commerce.Application.Features.Product.Requests.Commands
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
