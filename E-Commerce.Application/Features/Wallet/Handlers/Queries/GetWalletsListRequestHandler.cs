using AutoMapper;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Application.DTOs.Wallet;
using E_Commerce.Application.Features.Wallet.Requests.Queries;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Wallet.Handlers.Queries
{
    public class GetWalletsListRequestHandler : IRequestHandler<GetWalletsListRequest
        , List<WalletDto>>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public GetWalletsListRequestHandler(IMapper mapper ,IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<List<WalletDto>> Handle(GetWalletsListRequest request, CancellationToken cancellationToken)
        {
            var wallets = await _walletRepository.GetAll();
            return _mapper.Map<List<WalletDto>>(wallets);
        }
    }
}
