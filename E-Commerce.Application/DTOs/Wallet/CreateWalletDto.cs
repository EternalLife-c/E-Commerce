using E_Commerce.Application.DTOs.Common;
using E_Commerce.Application.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Wallet
{
    public class CreateWalletDto : BaseDto, IWalletDto
    {
        public int UserId { get; set; }
    }
}
