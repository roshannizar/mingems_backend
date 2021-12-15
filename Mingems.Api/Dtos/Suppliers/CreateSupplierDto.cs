using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Suppliers
{
    public class CreateSupplierDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
    }
}
