using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain
{
    public class CartItem : BaseDomainEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }

        //Navigation Properties
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}