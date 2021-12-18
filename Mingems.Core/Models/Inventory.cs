using Mingems.Shared.Core.Models;
using System;
using System.Collections.Generic;
using Mingems.Shared.Core.Enums;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mingems.Core.Models
{
    public class Inventory : AuditableEntity
    {
        public List<ImageLines> ImageLines { get; set; }
        public string InvenstorId { get; set; }
        [ForeignKey("InvestorId")]
        public virtual Investment Investment { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal RecuttingCost { get; set; }
        public decimal CertificateCost { get; set; }
        public decimal CommissionCost { get; set; }
        public decimal ExportCost { get; set; }
        public string Measurement { get; set; }
        public string Weight { get; set; }
        public string PriceCode { get; set; }
        public string LastPriceCode { get; set; }

        #region Private Methods
        private List<ImageLines> CreateOrUpdateImageLines(string user, List<ImageLines> imageLines)
        {
            foreach(var image in ImageLines)
            {
                var item = ImageLines.FirstOrDefault(i => i.InventoryId == Id && i.Id == image.Id);
                if(item == null)
                {
                    image.Id = Guid.NewGuid().ToString();
                    image.InventoryId = Id;
                    image.CreationDate = DateTime.UtcNow;
                    image.CreatedBy = user;
                }
            }

            return imageLines;
        }
        #endregion

        public Inventory Create(string user, Inventory inventory)
        {
            Id = Guid.NewGuid().ToString();
            ImageLines = CreateOrUpdateImageLines(user, inventory.ImageLines);
            InvenstorId = inventory.InvenstorId;
            Barcode = inventory.Barcode;
            Name = inventory.Name;
            Description = inventory.Description;
            UnitPrice = inventory.UnitPrice;
            RecuttingCost = inventory.RecuttingCost;
            CertificateCost = inventory.CertificateCost;
            CommissionCost = inventory.CommissionCost;
            Measurement = inventory.Measurement;
            Weight = inventory.Weight;
            PriceCode = inventory.PriceCode;
            LastPriceCode = inventory.LastPriceCode;

            RecordState = RecordState.Active;

            CreateAuditable(user);

            ModifiedAuditable(user);

            return this;
        }

        public Inventory Update(string user, Inventory inventory)
        {
            Id = inventory.Id;
            ImageLines = CreateOrUpdateImageLines(user, inventory.ImageLines);
            InvenstorId = inventory.InvenstorId;
            Barcode = inventory.Barcode;
            Name = inventory.Name;
            Description = inventory.Description;
            UnitPrice = inventory.UnitPrice;
            RecuttingCost = inventory.RecuttingCost;
            CertificateCost = inventory.CertificateCost;
            CommissionCost = inventory.CommissionCost;
            Measurement = inventory.Measurement;
            Weight = inventory.Weight;
            PriceCode = inventory.PriceCode;
            LastPriceCode = inventory.LastPriceCode;

            RecordState = RecordState.Active;


            ModifiedAuditable(user);

            return this;
        }

        public Inventory Delete(string user)
        {
            RecordState = RecordState.Removed;


            ModifiedAuditable(user);

            return this;
        }
    }
}
