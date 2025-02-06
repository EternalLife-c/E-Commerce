using E_Commerce.Application.Contracts.Persistence;
using E_Commerce.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly E_CommerceDbContext _dbContext;

        public UserRepository(E_CommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            return !await _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserNameUnique(string userName)
        {
            return !await _dbContext.Users.AnyAsync(u => u.UserName == userName);
        }
    }
}
