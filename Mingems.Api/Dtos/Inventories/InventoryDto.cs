using System;
using System.Collections.Generic;

namespace Mingems.Api.Dtos.Inventories
{
    public class InventoryDto
    {
        public string Id { get; set; }
        public List<ImageLinesDto> ImageLines { get; set; }
        public string InvestorId { get; set; }
        public virtual InventoryInvestorDto Investment { get; set; }
        public string SupplierId { get; set; }
        public InventorySupplierDto Supplier { get; set; }
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
        public DateTime TransactionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
