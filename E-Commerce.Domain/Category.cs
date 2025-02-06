using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
