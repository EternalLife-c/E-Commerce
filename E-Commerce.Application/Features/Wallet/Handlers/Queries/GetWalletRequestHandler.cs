using AutoMapper;
using E_Commerce.Application.DTOs.Wallet;
using E_Commerce.Application.Features.Wallet.Requests.Queries;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Wallet.Handlers.Queries
{
    public class GetWalletRequestHandler : IRequestHandler<GetWalletRequest, WalletDto>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public GetWalletRequestHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<WalletDto> Handle(GetWalletRequest request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.Get(request.Id);
            return _mapper.Map<WalletDto>(wallet);
        }
    }
}
