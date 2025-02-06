using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Transaction
{
    public interface ITransactionDto
    {
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
    }
}
