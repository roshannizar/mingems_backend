using Mingems.Shared.Core.Enums;
using System;

namespace Mingems.Shared.Core.Models
{
    public class AuditableEntity: BaseEntity<string>
    {
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public RecordState RecordState { get; set; }

        protected AuditableEntity CreateAuditable(string createdBy)
        {
            CreatedBy = createdBy;
            CreationDate = DateTime.UtcNow;
            return this;
        }

        protected AuditableEntity ModifiedAuditable(string modifiedBy)
        {
            ModifiedBy = modifiedBy;
            ModificationDate = DateTime.UtcNow;
            return this;
        }
    }
}
