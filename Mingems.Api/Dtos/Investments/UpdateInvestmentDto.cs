﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Investments
{
    public class UpdateInvestmentDto
    {
        public string Id { get; set; }
        public string RefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Amount { get; set; }
    }
}
