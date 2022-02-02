using System;

namespace Mingems.Api.Dtos.Purchases
{
    public class PurchaseDto
    {
        public string Id { get;  set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InvestorId { get; set; }
        public virtual PurchaseInvestmentDto Investment { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }
        public string SupplierId { get; set; }
        public virtual PurchaseSupplierDto Supplier { get; set; }
        public decimal ExportCost { get; set; }
        public bool Moved { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
