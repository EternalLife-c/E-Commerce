using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;

namespace E_Commerce.Application.DTOs.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public IProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .MaximumLength(150).WithMessage("{PropertyName} cannot exceed 150 characters.");

            RuleFor(e => e.Description)
                .MaximumLength(250).WithMessage("{PropertyName} cannot exceed 250 characters.");

            RuleFor(e => e.Price)
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be a non-negative number.");

            RuleFor(e => e.QuantityInStock)
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be a non-negative number.");

            RuleFor(e => e.ThumbnailPath)
                .Must(path => string.IsNullOrWhiteSpace(path) || Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
                .WithMessage("{PropertyName} must be a valid URL or file path.");

            RuleFor(e => e.IsAvailable)
                .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(e => e.CategoryId)
            .MustAsync(async (categoryId, cancellationToken) =>
            {
                if (!categoryId.HasValue) return true; // Allow null
                return await _categoryRepository.Exsits(categoryId.Value);
            }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
