using AutoMapper;
using E_Commerce.Application.DTOs.Transaction.Validators;
using E_Commerce.Application.DTOs.User.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Transaction.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Transaction.Handlers.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository
            , IMapper mapper, IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateTransactionDtoValidator(_userRepository, _walletRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTransactionDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var transaction = _mapper.Map<Domain.Transaction>(request.CreateTransactionDto);
            await _transactionRepository.Add(transaction);
            return transaction.Id;
        }
    }
}