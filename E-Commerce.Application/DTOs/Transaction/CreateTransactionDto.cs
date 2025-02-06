using E_Commerce.Application.DTOs.Common;
using E_Commerce.Domain.Enums;
using System;

namespace E_Commerce.Application.DTOs.Transaction
{
    public class CreateTransactionDto : BaseDto, ITransactionDto
    {
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
    }
}
