using AutoMapper;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Wallet.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
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

            if (wallet == null)
                throw new NotFoundException(nameof(Domain.Wallet), request.Id);

            await _walletRepository.Delete(wallet);
            return Unit.Value;
        }
    }
}
