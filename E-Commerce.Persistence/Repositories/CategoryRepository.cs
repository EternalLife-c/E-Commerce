using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;

namespace E_Commerce.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly E_CommerceDbContext _dbContext;

        public CategoryRepository(E_CommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
