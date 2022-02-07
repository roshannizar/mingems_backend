using Mingems.Shared.Core.Models;
using System;
using Mingems.Shared.Core.Enums;

namespace Mingems.Core.Models
{
    public class PrivateCode : AuditableEntity
    {
        public string Name { get; set; }
        public string PriceCode { get; set; }

        public PrivateCode Create(string user, PrivateCode privateCode)
        {
            Id = Guid.NewGuid().ToString();
            Name = privateCode.Name;
            PriceCode = privateCode.PriceCode;

            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public PrivateCode Update(string user, PrivateCode privateCode)
        {
            Id = privateCode.Id;
            Name = privateCode.Name;
            PriceCode = privateCode.PriceCode;

            RecordState = RecordState.Active;

            ModifiedAuditable(user);

            return this;
        }

        public PrivateCode Delete(string user)
        {
            RecordState = RecordState.Removed;

            ModifiedAuditable(user);

            return this;
        }
    }
}
