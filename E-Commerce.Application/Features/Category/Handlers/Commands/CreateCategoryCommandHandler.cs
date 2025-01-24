using AutoMapper;
using E_Commerce.Application.Features.Category.Requests.Commands;
using E_Commerce.Application.Persistence.Contracts;
using E_Commerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.Application.Features.Category.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository
            , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =_mapper.Map<Domain.Category>(request.CreateCategoryDto);
            await _categoryRepository.Add(category);
            return request.CreateCategoryDto.Id;
        }
    }
}
