using Mingems.Shared.Core.Models;
using Mingems.Shared.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mingems.Core.Models
{
    public class Investment : AuditableEntity
    {
        public string RefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ContactNo { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Amount { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal RemainingAmount { get; set; }

        public Investment Create(string user, Investment investment)
        {
            Id = Guid.NewGuid().ToString();
            RefId = Id.Substring(0, 4);
            FirstName = investment.FirstName;
            LastName = investment.LastName;
            Email = investment.Email;
            TransactionDate = DateTime.UtcNow;
            ContactNo = investment.ContactNo;
            Amount = investment.Amount;
            RemainingAmount = Amount;
            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public Investment Update(string user, Investment investment)
        {
            Id = investment.Id;
            RefId = investment.RefId;
            FirstName = investment.FirstName;
            LastName = investment.LastName;
            Email = investment.Email;
            TransactionDate = investment.TransactionDate;
            ContactNo = investment.ContactNo;
            RemainingAmount = RemainingAmount + (investment.Amount - Amount);
            Amount = investment.Amount;
            RecordState = RecordState.Active;

            ModifiedAuditable(user);

            return this;
        }

        public Investment Delete(string user)
        {
            RecordState = RecordState.Removed;

            ModifiedAuditable(user);

            return this;
        }

        public Investment AddRemainingAmount(string user, decimal amount)
        {
            if (amount <= RemainingAmount)
                RemainingAmount = RemainingAmount - amount;
            else
                throw new InvalidOperationException("Investor amount balance exceeded");

            ModifiedAuditable(user);
            return this;
        }

        public Investment UpdateRemainingAmount(string user, decimal amount, decimal previousAmount)
        {
            if (amount <= RemainingAmount)
                RemainingAmount = RemainingAmount - (amount - previousAmount);
            else
                throw new InvalidOperationException("Investor amount balance exceeded");

            ModifiedAuditable(user);
            return this;
        }

        public Investment DeletedRemainingAmount(string user, decimal amount)
        {
            RemainingAmount = RemainingAmount + amount;

            ModifiedAuditable(user);
            return this;
        }
    }
}
