using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly E_CommerceDbContext _dbContext;

        public OrderRepository(E_CommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
