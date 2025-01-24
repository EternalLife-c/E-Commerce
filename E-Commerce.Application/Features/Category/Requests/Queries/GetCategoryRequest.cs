using E_Commerce.Application.DTOs.Cart;
using E_Commerce.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Category.Requests.Queries
{
    public class GetCategoryRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
