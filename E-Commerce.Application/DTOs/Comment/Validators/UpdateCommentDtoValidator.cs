using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Comment.Validators
{
    public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public UpdateCommentDtoValidator(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            Include(new ICommentDtoValidator(_userRepository, _productRepository));
        }
    }
}
