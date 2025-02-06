using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IGenericRepository<Domain.Transaction>
    {
        
    }
}
