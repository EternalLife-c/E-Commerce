using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Comment.Requests.Commands
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
