using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Comment
{
    public class CommentDto : BaseDto, ICommentDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
