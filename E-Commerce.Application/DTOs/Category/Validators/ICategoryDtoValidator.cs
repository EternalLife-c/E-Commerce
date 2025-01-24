using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Category.Validators
{
    public class ICategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        public ICategoryDtoValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.");

            RuleFor(e => e.Description)
                .MaximumLength(250).WithMessage("{PropertyName} cannot exceed 250 characters.");
        }
    }
}