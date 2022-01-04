using Mingems.Shared.Core.Enums;
using System;

namespace Mingems.Api.Dtos.Users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IpAddress { get; set; }
        public DateTime LastLoggedDate { get; set; }
        public Role Role { get; set; }
        public bool Verify { get; set; }
    }
}
