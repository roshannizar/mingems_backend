using Mingems.Shared.Core.Models;
using Mingems.Shared.Core.Enums;

namespace Mingems.Core.Models
{
    public class Supplier : AuditableEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }

        public Supplier Create(string user, Supplier supplier)
        {
            Id = supplier.Id;
            Name = supplier.Name;
            City = supplier.City;
            ContactNo = supplier.ContactNo;
            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public Supplier Update(string user, Supplier supplier)
        {
            Id = supplier.Id;
            Name = supplier.Name;
            City = supplier.City;
            ContactNo = supplier.ContactNo;
            RecordState = RecordState.Active;

            ModifiedAuditable(user);

            return this;
        }

        public Supplier Delete(string user)
        {
            RecordState = RecordState.Removed;

            ModifiedAuditable(user);

            return this;
        }
    }
}
