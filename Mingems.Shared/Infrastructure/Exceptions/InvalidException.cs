using System;

namespace Mingems.Shared.Infrastructure.Exceptions
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message) { }
    }
}
