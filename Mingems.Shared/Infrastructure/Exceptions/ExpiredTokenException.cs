using System;

namespace Mingems.Shared.Infrastructure.Exceptions
{
    public class ExpiredTokenException : Exception
    {
        public ExpiredTokenException(string message) : base(message) { }
    }
}
