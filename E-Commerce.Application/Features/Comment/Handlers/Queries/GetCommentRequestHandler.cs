using AutoMapper;
using E_Commerce.Application.DTOs.Comment;
using E_Commerce.Application.Features.Comment.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Comment.Handlers.Queries
{
    public class GetCommentRequestHandler : IRequestHandler<GetCommentRequest, CommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.Get(request.Id);
            return _mapper.Map<CommentDto>(comment);
        }
    }
}
