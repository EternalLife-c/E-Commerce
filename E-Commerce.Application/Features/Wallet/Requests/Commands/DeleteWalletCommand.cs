using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.Wallet.Requests.Commands
{
    public class DeleteWalletCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
