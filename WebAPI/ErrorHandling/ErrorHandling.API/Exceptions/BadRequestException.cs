using System;
using System.Net;

namespace ErrorHandling.API.Exceptions
{
    public class BadRequestException : CustomExceptionBase
    {
        public BadRequestException(string message) : base((int)HttpStatusCode.BadRequest, message) { }

        public BadRequestException(string message, Exception innerException) : base((int)HttpStatusCode.BadRequest, message, innerException) { }
    }
}