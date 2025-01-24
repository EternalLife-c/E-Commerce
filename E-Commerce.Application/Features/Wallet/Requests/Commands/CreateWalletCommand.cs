using E_Commerce.Application.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Wallet.Requests.Commands
{
    public class CreateWalletCommand : IRequest<int>
    {
        public CreateWalletDto CreateWalletDto { get; set; }
    }
}