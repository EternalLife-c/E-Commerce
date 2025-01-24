using E_Commerce.Domain.Common;
using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Commerce.Domain
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public int UserId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

