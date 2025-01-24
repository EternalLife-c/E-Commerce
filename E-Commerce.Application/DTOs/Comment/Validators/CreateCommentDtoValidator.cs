using E_Commerce.Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Comment.Validators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public CreateCommentDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            Include(new ICommentDtoValidator(_userRepository, _productRepository));
        }
    }
}
