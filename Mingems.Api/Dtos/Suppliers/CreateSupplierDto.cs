﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Api.Dtos.Suppliers
{
    public class CreateSupplierDto
    {
        [EmailAddress]
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
    }
}
