using AutoMapper;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Comment.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Comment.Handlers.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.Get(request.Id);

            if (comment == null)
            {
                throw new NotFoundException(nameof(Domain.Comment), request.Id);
            }

            await _commentRepository.Delete(comment);
            return Unit.Value;
        }
    }
}
