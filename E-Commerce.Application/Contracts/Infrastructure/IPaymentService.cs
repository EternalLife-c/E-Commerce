using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Contracts.Infrastructure
{
    public interface IPaymentService
    {
        public bool ProcessPayemnt(decimal amount, int userId, bool useWallet);
    }
}
