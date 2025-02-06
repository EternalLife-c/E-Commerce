using E_Commerce.Application.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Product
{
    public interface IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string ThumbnailPath { get; set; }
        public bool IsAvailable { get; set; }
        public int? CategoryId { get; set; }
    }
}
