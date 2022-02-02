using Mingems.Shared.Core.Enums;
using System;

namespace Mingems.Api.Dtos.Subscriptions
{
    public class SubscriptionDto
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Cost { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
