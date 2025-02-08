using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain
{
    public class OrderItem : BaseDomainEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        //Navigation Properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
