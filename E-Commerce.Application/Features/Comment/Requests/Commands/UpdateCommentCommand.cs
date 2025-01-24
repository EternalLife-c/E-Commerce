using E_Commerce.Application.DTOs.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Comment.Requests.Commands
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public UpdateCommentDto UpdateCommentDto { get; set; }
    }
}
