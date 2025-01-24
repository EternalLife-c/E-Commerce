using AutoMapper;
using E_Commerce.Application.Features.Wallet.Requests.Commands;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Wallet.Handlers.Commands
{
    public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand, Unit>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public DeleteWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.Get(request.Id);
            await _walletRepository.Delete(wallet);
            return Unit.Value;
        }
    }
}
