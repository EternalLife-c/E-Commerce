using AutoMapper;
using E_Commerce.Application.DTOs.User;
using E_Commerce.Application.Features.User.Requests.Queries;
using E_Commerce.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.User.Handlers.Queries
{
    public class GetUsersListRequestHandler : IRequestHandler<GetUsersListRequest, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUsersListRequest request, CancellationToken cancellationToken)
        {
            var Users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(Users);
        }
    }
}
