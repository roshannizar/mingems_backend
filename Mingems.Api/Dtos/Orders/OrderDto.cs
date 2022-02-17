using Mingems.Shared.Core.Enums;
using System;
using System.Collections.Generic;

namespace Mingems.Api.Dtos.Orders
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string RefId { get; set; }
        public string CustomerId { get; set; }
        public virtual OrderCustomerDto Customer { get; set; }
        public List<OrderLineDto> OrderLines { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
