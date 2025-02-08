using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Contracts.Infrastructure
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string password, string hashedPassword);
    }
}
