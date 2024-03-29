﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Suppliers
{
    public class SupplierDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
