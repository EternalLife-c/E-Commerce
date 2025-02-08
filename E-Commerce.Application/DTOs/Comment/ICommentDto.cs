using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Comment
{
    public interface ICommentDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
