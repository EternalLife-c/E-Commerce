using E_Commerce.Application.Contracts.Persistence;
using FluentValidation;

namespace E_Commerce.Application.DTOs.Transaction.Validators
{
    public class CreateTransactionDtoValidator : AbstractValidator<CreateTransactionDto>
    {
        private readonly IWalletRepository _walletRepository;

        public CreateTransactionDtoValidator(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            Include(new ITransactionDtoValidator (_walletRepository));
        }
    }
}
