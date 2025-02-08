using AutoMapper;
using E_Commerce.Application.DTOs.Comment.Validators;
using E_Commerce.Application.DTOs.Order.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Comment.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Comment.Handlers.Commands
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository
            ,IUserRepository userRepository,IProductRepository productRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateCommentDtoValidator(_userRepository , _productRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCommentDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var comment = _mapper.Map<Domain.Comment>(request.CreateCommentDto);
            comment.PostedDate = DateTime.Now;

            await _commentRepository.Add(comment);
            return Unit.Value;
        }
    }
}
