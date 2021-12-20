﻿using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Purchases
{
    public class CreatePurchaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string InvestorId { get; set; }
        public decimal UnitPrice { get; set; }
        [Required]
        public string SupplierId { get; set; }
        public decimal ExportCost { get; set; }
    }
}
