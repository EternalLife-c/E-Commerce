using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            Include(new IProductDtoValidator(_categoryRepository));
        }
    }
}
