using Mingems.Shared.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mingems.Shared.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Mingems.Core.Models
{
    public class Purchase : AuditableEntity
    {
        public List<ImageLines> ImageLines { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InvestorId { get; set; }
        [ForeignKey("InvestorId")]
        public virtual Investment Investment { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public decimal RecuttingCost { get; set; }
        public decimal CertificateCost { get; set; }
        public decimal? CommissionCost { get; set; }
        public decimal ExportCost { get; set; }
        public string? Measurement { get; set; }
        public string? Weight { get; set; }
        public string? PriceCode { get; set; }
        public string? LastPriceCode { get; set; }
        public bool Moved { get; set; }

        #region Not Mapped Fields
        [NotMapped]
        public string PreviousInvestorId { get; set; }
        #endregion

        #region Private Methods
        private List<ImageLines> CreateOrUpdateImageLines(string user, List<ImageLines> imageLines)
        {
            if (imageLines != null)
            {
                foreach (var image in imageLines)
                {
                    if (ImageLines != null)
                    {
                        var item = ImageLines.FirstOrDefault(i => i.PurchaseId == Id && i.Id == image.Id);
                        if (item == null)
                        {
                            image.Id = Guid.NewGuid().ToString();
                            image.PurchaseId = Id;
                            image.CreationDate = DateTime.UtcNow;
                            image.CreatedBy = user;
                            image.RecordState = RecordState.Active;
                        }
                    } else
                    {
                        image.Id = Guid.NewGuid().ToString();
                        image.PurchaseId = Id;
                        image.CreationDate = DateTime.UtcNow;
                        image.CreatedBy = user;
                        image.RecordState = RecordState.Active;
                    }
                }
            }

            return imageLines;
        }
        #endregion

        public Purchase Create(string user, Purchase purchase)
        {
            Id = Guid.NewGuid().ToString();
            Barcode = Id.Substring(0, 8);
            Name = purchase.Name;
            ImageLines = CreateOrUpdateImageLines(user, purchase.ImageLines);
            Description = purchase.Description;
            InvestorId = purchase.InvestorId;
            UnitPrice = purchase.UnitPrice;
            Quantity = 1;
            RecuttingCost = purchase.RecuttingCost;
            CertificateCost = purchase.CertificateCost;
            CommissionCost = purchase.CommissionCost;
            Measurement = purchase.Measurement;
            Weight = purchase.Weight;
            PriceCode = purchase.PriceCode;
            LastPriceCode = purchase.LastPriceCode;
            SupplierId = purchase.SupplierId;
            ExportCost = purchase.ExportCost;
            TransactionDate = DateTime.UtcNow;
            Moved = purchase.Moved;

            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }

        public Purchase Update(string user, Purchase purchase)
        {
            Id = purchase.Id;
            Barcode = Id.Substring(0, 8);
            Name = purchase.Name;
            ImageLines = CreateOrUpdateImageLines(user, purchase.ImageLines);
            Description = purchase.Description;
            InvestorId = purchase.InvestorId;
            UnitPrice = purchase.UnitPrice;
            Quantity = purchase.Quantity;
            RecuttingCost = purchase.RecuttingCost;
            CertificateCost = purchase.CertificateCost;
            CommissionCost = purchase.CommissionCost;
            Measurement = purchase.Measurement;
            Weight = purchase.Weight;
            PriceCode = purchase.PriceCode;
            LastPriceCode = purchase.LastPriceCode;
            ExportCost = purchase.ExportCost;
            SupplierId = purchase.SupplierId;
            Moved = purchase.Moved;

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

        public Purchase MovedStatus(string user, Purchase purchase)
        {
            Moved = true;
            ImageLines = CreateOrUpdateImageLines(user, purchase.ImageLines);
            Quantity = 1;
            RecuttingCost = purchase.RecuttingCost;
            CertificateCost = purchase.CertificateCost;
            CommissionCost = purchase.CommissionCost;
            Measurement = purchase.Measurement;
            Weight = purchase.Weight;
            PriceCode = purchase.PriceCode;
            LastPriceCode = purchase.LastPriceCode;
            ExportCost = purchase.ExportCost;
            RecordState = RecordState.Active;

            Investment = null;
            Supplier = null;

            ModifiedAuditable(user);

            return this;
        }

        public Purchase RevertMovedStatus(string user)
        {
            Moved = false;
            Quantity = 1;
            RecordState = RecordState.Active;

            Investment = null;
            Supplier = null;

            ModifiedAuditable(user);

            return this;
        }

        public Purchase UpdateQuantity(string user)
        {
            Quantity = 0;
            RecordState = RecordState.Active;

            Investment = null;
            Supplier = null;

            ModifiedAuditable(user);

            return this;
        }
    }
}
