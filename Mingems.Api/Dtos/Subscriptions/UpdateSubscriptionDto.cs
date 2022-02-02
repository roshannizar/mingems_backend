using System;

namespace Mingems.Api.Dtos.Subscriptions
{
    public class UpdateSubscriptionDto
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Cost { get; set; }
    }
}
