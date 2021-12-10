using System;

namespace Mingems.Shared.Infrastructure.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}
