using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly E_CommerceDbContext _dbContext;

        public CartRepository(E_CommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}