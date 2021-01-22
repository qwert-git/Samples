using System;

namespace ErrorHandling.API.Exceptions
{
    public abstract class CustomExceptionBase : Exception
    {
        public int StatusCode { get; private set; }

        public CustomExceptionBase(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomExceptionBase(int statusCode, string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}