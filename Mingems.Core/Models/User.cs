using Mingems.Shared.Core.Enums;
using Mingems.Shared.Core.Extensions;
using Mingems.Shared.Core.Models;
using System;

namespace Mingems.Core.Models
{
    public class User: AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public DateTime LastLoggedDate { get; set; }
        public bool Verify { get; set; }
        public Role Role { get; set; }

        public User Create(string email, User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = Password.Encrypt();
            Verify = false;
            Role = Role.Customer;
            RecordState = RecordState.Active;

            CreateAuditable(email);
            ModifiedAuditable(email);

            return this;
        }

        public User Update(string email, User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;

            ModifiedAuditable(email);

            return this;
        }

        public User Delete(string email)
        {
            RecordState = RecordState.Removed;

            ModifiedAuditable(email);

            return this;
        }

        public User VerifyAccount()
        {
            Verify = true;
            LastLoggedDate = DateTime.UtcNow;

            ModifiedAuditable(Id);

            return this;
        }

        public User LoggedDate()
        {
            LastLoggedDate = DateTime.UtcNow;

            return this;
        }

        public User UpdatePassword(string password)
        {
            Password = password.Encrypt();

            ModifiedAuditable(Id);

            return this;
        }
    }
}
