using AutoMapper;
using E_Commerce.Application.DTOs.Category.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Category.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Category.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository
            , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            #endregion

            var category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);
            _mapper.Map(request.UpdateCategoryDto, category);
            await _categoryRepository.Update(category);
            return Unit.Value;
        }
    }
}
