using System;

namespace Mingems.Api.Dtos.Users
{
    public class LastLoggedDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IpAddress { get; set; }
        public DateTime LastLoggedDate { get; set; }
    }
}
