using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Features.User.Requests.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
