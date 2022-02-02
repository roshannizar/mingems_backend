using Mingems.Shared.Core.Enums;
using Mingems.Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mingems.Core.Models
{
    public class Subscription :AuditableEntity
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Cost { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }

        public Subscription Create(Subscription subscription)
        {
            Id = Guid.NewGuid().ToString();
            ImageUrl = subscription.ImageUrl;
            Description = subscription.Description;
            BillDate = subscription.BillDate;
            DueDate = subscription.DueDate;
            Cost = subscription.Cost;
            SubscriptionStatus = SubscriptionStatus.NotPaid;

            RecordState = RecordState.Active;

            CreateAuditable("System");
            ModifiedAuditable("System");

            return this;
        }

        public Subscription Update(Subscription subscription)
        {
            Id = subscription.Id;
            ImageUrl = subscription.ImageUrl;
            Description = subscription.Description;
            BillDate = subscription.BillDate;
            DueDate = subscription.DueDate;
            Cost = subscription.Cost;
            SubscriptionStatus = SubscriptionStatus.Pending;

            RecordState = RecordState.Active;

            ModifiedAuditable("System");

            return this;
        }

        public Subscription Delete()
        {

            RecordState = RecordState.Removed;

            ModifiedAuditable("System");

            return this;
        }
    }
}
