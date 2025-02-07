using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Category
{
    public class UpdateCategoryDto : BaseDto, ICategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}