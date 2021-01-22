using System;
using System.Net;

namespace ErrorHandling.API.Exceptions
{
    public class NotFoundException : CustomExceptionBase
    {
        public NotFoundException(string message)
            : base((int)HttpStatusCode.NotFound, message) { }

        public NotFoundException(string message, Exception innerException)
            : base((int)HttpStatusCode.NotFound, message, innerException) { }
    }
}