using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Api.Dtos.Suppliers
{
    public class CreateSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
    }
}
