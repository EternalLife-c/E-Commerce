using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Enums;
using E_Commerce.Application.DTOs.Wallet;
using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Transaction
{
    public class TransactionDto : BaseDto
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeDto TransactionType { get; set; }
        public bool Successful { get; set; }
        public int WalletId { get; set; }
    }
}