﻿using E_Commerce.Application.DTOs.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Comment.Requests.Queries
{
    public class GetCommentRequest : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}
