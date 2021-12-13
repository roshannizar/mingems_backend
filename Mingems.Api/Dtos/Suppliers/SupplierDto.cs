using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Suppliers
{
    public class SupplierDto
    {
        [EmailAddress]
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
    }
}
