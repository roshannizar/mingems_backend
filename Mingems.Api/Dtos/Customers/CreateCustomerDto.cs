using System.ComponentModel.DataAnnotations;

namespace Mingems.Api.Dtos.Customers
{
    public class CreateCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ContactNo { get; set; }
    }
}
