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
    public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, Unit>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public UpdateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.Get(request.UpdateWalletDto.Id);
            _mapper.Map(request.UpdateWalletDto, wallet);
            await _walletRepository.Update(wallet);
            return Unit.Value;
        }
    }
}
