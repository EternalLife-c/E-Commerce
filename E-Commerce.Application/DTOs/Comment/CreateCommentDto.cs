using E_Commerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Comment
{
    public class CreateCommentDto : ICommentDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
