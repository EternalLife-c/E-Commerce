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
    public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, Unit>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateWalletCommandHandler(IWalletRepository walletRepository, IMapper mapper
            ,IUserRepository userRepository)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateWalletDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateWalletDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var wallet = await _walletRepository.Get(request.UpdateWalletDto.Id);
            _mapper.Map(request.UpdateWalletDto, wallet);
            await _walletRepository.Update(wallet);
            return Unit.Value;
        }
    }
}
