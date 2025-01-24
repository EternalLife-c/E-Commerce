using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Wallet
{
    public class CreateWalletDto : BaseDto, IWalletDto
    {
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
