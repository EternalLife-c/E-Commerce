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
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, int>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public CreateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = _mapper.Map<Domain.Wallet>(request.CreateWalletDto);
            await _walletRepository.Add(wallet);
            return wallet.Id;
        }
    }
}
