using E_Commerce.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.User.Requests.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
