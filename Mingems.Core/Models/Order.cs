
using Mingems.Shared.Core.Enums;
using Mingems.Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mingems.Core.Models
{
    public class Order : AuditableEntity
    {
        public string RefId { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal VAT { get; set; }

        #region Private Methods
        private List<OrderLine> CreateOrUpdateOrderLine(string user, List<OrderLine> orderLine)
        {
            foreach (var item in OrderLines)
            {
                var isExist = OrderLines.FirstOrDefault(o => o.OrderId == Id && o.ProductId == item.ProductId);

                if (isExist == null)
                    item.Create(user, item, Id);
                else
                    item.Update(user, item);
            }

            return orderLine;
        }

        private decimal CalculateTotal()
        {
            decimal totalAmount = 0;
            foreach (var item in OrderLines)
            {
                totalAmount += item.Quantity * item.SoldPrice;
            }
            return totalAmount;
        }
        #endregion

        public Order Create(string user, Order order)
        {
            Id = Guid.NewGuid().ToString();
            RefId = Id.Substring(0,8);
            OrderLines = CreateOrUpdateOrderLine(user, order.OrderLines);
            CustomerId = order.CustomerId;
            TransactionDate = DateTime.UtcNow;
            PaymentDate = order.PaymentDate;
            OrderStatus = order.OrderStatus;
            PaymentType = order.PaymentType;
            Discount = order.Discount;
            VAT = order.VAT;
            TotalAmount = CalculateTotal();

            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public Order Update(string user, Order order)
        {
            Id = order.Id;
            RefId = order.RefId;
            OrderLines = CreateOrUpdateOrderLine(user, order.OrderLines);
            CustomerId = order.CustomerId;
            PaymentDate = order.PaymentDate;
            OrderStatus = order.OrderStatus;
            PaymentType = order.PaymentType;
            Discount = order.Discount;
            TotalAmount = CalculateTotal();
            VAT = order.VAT;

            RecordState = RecordState.Active;

            ModifiedAuditable(user);

            return this;
        }

        public Order Delete(string user)
        {
            RecordState = RecordState.Removed;

            ModifiedAuditable(user);

            return this;
        }
    }
}




