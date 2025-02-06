using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain
{
    public class User : BaseDomainEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; } = false;

        //Navigation Properties
        public Cart? Cart { get; set; }
        public Wallet? Wallet { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}