using E_Commerce.Application.DTOs.Common;
using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Transaction
{
    public class UpdateTransactionDto : BaseDto, ITransactionDto
    {
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
    }
}