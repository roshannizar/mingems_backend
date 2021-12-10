using System;

namespace Mingems.Shared.Infrastructure.Exceptions
{
    public class AccountVerificationFailedException : Exception
    {
        public AccountVerificationFailedException(string message) : base(message) { }
    }
}
