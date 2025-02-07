using AutoMapper;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Application.DTOs.Product.Validators;
using E_Commerce.Application.Exceptions;
using E_Commerce.Application.Features.Product.Requests.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository
            , ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new CreateProductDtoValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.CreateProductDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var product = _mapper.Map<Domain.Product>(request.CreateProductDto);
            await _productRepository.Add(product);
            return product.Id;
        }
    }
}