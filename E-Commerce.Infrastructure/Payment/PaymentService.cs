using E_Commerce.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure.Payment
{
    public class PaymentService : IPaymentService
    {
        //
        //Complete Later!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //

        public bool ProcessPayemnt(decimal amount, int userId, bool useWallet)
        {
            if (useWallet)
            {
                // Later, we can check the user's wallet balance here.
                return true;
            }
            else
            {
                // Later, we can check if the transaction was successfull or not.
                return true;
            }
        }
    }
}
