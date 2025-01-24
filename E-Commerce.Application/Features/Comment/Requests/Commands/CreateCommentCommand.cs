using E_Commerce.Application.DTOs.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Comment.Requests.Commands
{
    public class CreateCommentCommand : IRequest<int>
    {
        public CreateCommentDto CreateCommentDto { get; set; }
    }
}
