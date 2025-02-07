using AutoMapper;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
            user.RegisterDate = DateTime.Now;
            user.IsAdmin = false;

            await _userRepository.Add(user);
            return user.Id;
        }
    }
}