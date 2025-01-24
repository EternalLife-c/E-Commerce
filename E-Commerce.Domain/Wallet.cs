using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace E_Commerce.Domain
{
    public class Wallet : BaseEntity
    {
        public decimal Balance { get; set; }
        public int UserId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
