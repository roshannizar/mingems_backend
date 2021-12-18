using Mingems.Shared.Core.Models;
using Mingems.Shared.Core.Enums;
using System;

namespace Mingems.Core.Models
{
    public class Customer : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        public Customer Create(string user, Customer customer)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            ContactNo = customer.ContactNo;

            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public Customer Update(string user, Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            ContactNo = customer.ContactNo;

            RecordState = RecordState.Active;

            ModifiedAuditable(user);

            return this;
        }

        public Customer Delete(string user)
        {
            RecordState = RecordState.Removed;

            ModifiedAuditable(user);

            return this;
        }
    }
}
