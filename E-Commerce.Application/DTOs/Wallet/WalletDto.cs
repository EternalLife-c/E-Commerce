using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Transaction;
using E_Commerce.Application.DTOs.User;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Wallet
{
    public class WalletDto : BaseDto
    {
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
