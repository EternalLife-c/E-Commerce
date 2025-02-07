using E_Commerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Order
{
    public class UpdateOrderPaymentStatusDto : BaseDto, IOrderDto
    {
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
    }
}