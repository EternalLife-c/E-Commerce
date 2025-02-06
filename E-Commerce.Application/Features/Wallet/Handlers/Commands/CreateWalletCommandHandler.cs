using AutoMapper;
using E_Commerce.Application.DTOs.Wallet.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Wallet.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper
            , IUserRepository userRepository)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateWalletDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.CreateWalletDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var wallet = _mapper.Map<Domain.Wallet>(request.CreateWalletDto);
            await _walletRepository.Add(wallet);
            return wallet.Id;
        }
    }
}
