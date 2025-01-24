using E_Commerce.Application.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Wallet.Requests.Queries
{
    public class GetWalletRequest : IRequest<WalletDto>
    {
        public int Id { get; set; }
    }
}
