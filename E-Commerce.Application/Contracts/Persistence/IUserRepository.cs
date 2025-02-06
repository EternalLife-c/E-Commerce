using E_Commerce.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<bool> IsUserNameUnique(string userName);
        public Task<bool> IsEmailUnique(string email);
    }
}