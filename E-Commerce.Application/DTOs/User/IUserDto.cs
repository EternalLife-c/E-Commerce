using E_Commerce.Application.DTOs.Order;
using E_Commerce.Application.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.User
{
    public interface IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }
        public int? WalletId { get; set; }
        public int? CartId { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
