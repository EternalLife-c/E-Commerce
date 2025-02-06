using AutoMapper;
using E_Commerce.Application.DTOs.User.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.User.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.User.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateUserDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateUserDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var User = await _userRepository.Get(request.UpdateUserDto.Id);
            _mapper.Map(request.UpdateUserDto, User);
            await _userRepository.Update(User);
            return Unit.Value;
        }
    }
}
