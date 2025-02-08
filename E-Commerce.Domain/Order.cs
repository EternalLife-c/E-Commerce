using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;

namespace E_Commerce.Domain
{
    public class Order : BaseDomainEntity
    {
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDone { get; set; }
        public Guid UserId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}