using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Suppliers
{
    public class UpdateSupplierDto
    {
        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
    }
}
