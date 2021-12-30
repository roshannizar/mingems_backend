using Mingems.Shared.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mingems.Shared.Core.Enums;

namespace Mingems.Core.Models
{
    public class Purchase : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string InvestorId { get; set; }
        [ForeignKey("InvestorId")]
        public virtual Investment Investment { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public string SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public decimal ExportCost { get; set; }

        #region Not Mapped Fields
        [NotMapped]
        public string PreviousInvestorId { get; set; }
        #endregion

        public Purchase Create(string user, Purchase purchase)
        {
            Id = Guid.NewGuid().ToString();
            Name = purchase.Name;
            Description = purchase.Description;
            InvestorId = purchase.InvestorId;
            UnitPrice = purchase.UnitPrice;
            SupplierId = purchase.SupplierId;
            ExportCost = purchase.ExportCost;
            TransactionDate = DateTime.UtcNow;

            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public Purchase Update(string user, Purchase purchase)
        {
            Id = purchase.Id;
            Name = purchase.Name;
            Description = purchase.Description;
            InvestorId = purchase.InvestorId;
            UnitPrice = purchase.UnitPrice;
            SupplierId = purchase.SupplierId;
            ExportCost = purchase.ExportCost;

            Investment = null;
            Supplier = null;

            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }
        
        public Purchase Delete(string user)
        {
            Investment = null;
            Supplier = null;
            RecordState = RecordState.Removed;

            ModifiedAuditable(user);

            return this;
        }
    }
}
