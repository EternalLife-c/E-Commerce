using AutoMapper;
using E_Commerce.Application.DTOs.Category.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Category.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Category.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository
            , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion

            var category = _mapper.Map<Domain.Category>(request.CreateCategoryDto);
            await _categoryRepository.Add(category);
            return Unit.Value;
        }
    }
}