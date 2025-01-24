using E_Commerce.Domain.Common;
using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain
{
    public class Transaction : BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public bool Successful { get; set; }
        public int WalletId { get; set; }
        public int UserId { get; set; }

        //Navigation Properties
        public Wallet Wallet { get; set; }
        public User User { get; set; }
    }
}