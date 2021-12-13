using System;

namespace Mingems.Api.Dtos.Investments
{
    public class InvestmentDto
    {
        public string Id { get; set; }
        public string RefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ContactNo { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
