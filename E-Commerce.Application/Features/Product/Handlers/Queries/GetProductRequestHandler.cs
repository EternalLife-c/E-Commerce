using AutoMapper;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.Features.Product.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Product.Handlers.Queries
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var prodcut = await _productRepository.Get(request.Id);
            return _mapper.Map<ProductDto>(prodcut);
        }
    }
}
