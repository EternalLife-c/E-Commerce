using AutoMapper;
using E_Commerce.Application.DTOs.Product.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Product.Requests.Commands;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository
            ,ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new UpdateProductDtoValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateProductDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var product = await _productRepository.Get(request.UpdateProductDto.Id);
            _mapper.Map(request.UpdateProductDto, product);
            await _productRepository.Update(product);
            return Unit.Value;
        }
    }
}
