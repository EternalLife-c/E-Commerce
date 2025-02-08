using E_Commerce.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.User.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
