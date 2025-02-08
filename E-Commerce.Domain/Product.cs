using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain
{
    public class Product : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string ThumbnailPath { get; set; }
        public bool IsAvailable { get; set; }
        public Guid? CategoryId { get; set; }

        //Navigation Properties
        public Category? Category { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}