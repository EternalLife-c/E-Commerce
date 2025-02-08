using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain
{
    public class Comment : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        //Navigation Properties
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
