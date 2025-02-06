using AutoMapper;
using E_Commerce.Application.DTOs.Category;
using E_Commerce.Application.Features.Category.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Category.Handlers.Queries
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
