using AutoMapper;
using E_Commerce.Application.DTOs.Category;
using E_Commerce.Application.Features.Category.Requests.Queries;
using E_Commerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Category.Handlers.Queries
{
    public class GetCategoriesListRequestHandler : IRequestHandler<GetCategoriesListRequest
        , List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoriesListRequest request
            , CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
