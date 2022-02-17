using Mingems.Shared.Core.Enums;
using System;
using System.Collections.Generic;

namespace Mingems.Api.Dtos.Orders
{
    public class CreateOrderDto
    {
        public string CustomerId { get; set; }
        public List<CreateOrderLineDto> OrderLines { get; set; }
        public DateTime PaymentDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Discount { get; set; }
    }
}
