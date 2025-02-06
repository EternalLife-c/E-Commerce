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
        public int UserId { get; set; }
        public int ProductId { get; set; }

        //Navigation Properties
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
