using AutoMapper;
using E_Commerce.Application.Contracts.Infrastructure;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Application.DTOs.User.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.User.Requests.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository,IPasswordHasher passwordHasher
            , IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateUserDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.CreateUserDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var user = _mapper.Map<Domain.User>(request.CreateUserDto);
            user.PasswordHash = _passwordHasher.HashPassword(request.CreateUserDto.PasswordHash);
            user.RegisterDate = DateTime.Now;
            user.IsAdmin = false;

            await _userRepository.Add(user);
            return Unit.Value;
        }
    }
}