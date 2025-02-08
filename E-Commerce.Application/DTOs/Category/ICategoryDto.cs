using E_Commerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Category
{
    public interface ICategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}