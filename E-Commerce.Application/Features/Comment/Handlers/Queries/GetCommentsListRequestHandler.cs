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
    public class GetCommentsListRequestHandler : IRequestHandler<GetCommentsListRequest
        , List<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentsListRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetCommentsListRequest request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAll();
            return _mapper.Map<List<CommentDto>>(comments);
        }
    }
}
