using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly E_CommerceDbContext _dbContext;

        public CommentRepository(E_CommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
