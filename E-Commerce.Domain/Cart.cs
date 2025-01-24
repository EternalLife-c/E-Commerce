using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Commerce.Domain
{
    public class Cart : BaseEntity
    {
        public decimal TotalCartPrice { get; set; }
        public int UserId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
