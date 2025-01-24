﻿using E_Commerce.Application.DTOs.Comment;
using E_Commerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Product
{
    public class CreateProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailPath { get; set; }
        public bool IsAvailable { get; set; }
        public int? CategoryId { get; set; }
    }
}