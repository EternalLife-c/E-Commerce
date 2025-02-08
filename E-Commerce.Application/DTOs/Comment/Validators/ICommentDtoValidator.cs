using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Comment.Validators
{
    public class ICommentDtoValidator : AbstractValidator<ICommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public ICommentDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;

            RuleFor(e => e.Title)
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(150).WithMessage("{PropertyName} cannot exceed 150 characters.");

            RuleFor(e => e.Content)
                .NotNull().WithMessage("{PropertyName} cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(1000).WithMessage("{PropertyName} cannot exceed 150 characters.")
                .MinimumLength(10).WithMessage("{PropertyName} cannot exceed 150 characters.");

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty or default.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} cannot be an empty GUID.").MustAsync(async (id, token) =>
                {
                    var UserExists = await _userRepository.Exsits(id);
                    return !UserExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(e => e.ProductId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty or default.")
                .Must(id => id != Guid.Empty).WithMessage("{PropertyName} cannot be an empty GUID.").MustAsync(async (id, token) =>
                {
                    var productExists = await _productRepository.Exsits(id);
                    return !productExists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
