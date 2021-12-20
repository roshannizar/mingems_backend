using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Inventories
{
    public class CreateInventoryDto
    {
        public List<CreateImageLinesDto> ImageLines { get; set; }
        [Required]
        public string InvestorId { get; set; }
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
    }
}
