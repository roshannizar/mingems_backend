using Mingems.Shared.Core.Models;
using Mingems.Shared.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mingems.Core.Models
{
    public class OrderLine : AuditableEntity
    {
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Purchase Purchase { get; set; }
        public int Quantity { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal ActualPrice { get; set; }

        public OrderLine Create(string user, OrderLine orderLine, string orderId)
        {
            Id = Guid.NewGuid().ToString();
            OrderId = orderId;
            ProductId = orderLine.ProductId;
            Quantity = orderLine.Quantity;
            SoldPrice = orderLine.SoldPrice;
            ActualPrice = orderLine.ActualPrice;

            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public OrderLine Update(string user, OrderLine orderLine)
        {
            Id = orderLine.Id;
            OrderId = orderLine.OrderId;
            ProductId = orderLine.ProductId;
            Quantity = orderLine.Quantity;
            SoldPrice = orderLine.SoldPrice;
            ActualPrice = orderLine.ActualPrice;

            RecordState = orderLine.RecordState;

            ModifiedAuditable(user);

            return this;
        }
    }
}
