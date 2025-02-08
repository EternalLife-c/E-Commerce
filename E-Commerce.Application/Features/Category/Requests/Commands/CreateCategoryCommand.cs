using E_Commerce.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Category.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
