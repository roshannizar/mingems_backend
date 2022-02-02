using System;

namespace Mingems.Api.Dtos.Subscriptions
{
    public class CreateSubscriptionDto
    {
        public string Description { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Cost { get; set; }
    }
}
