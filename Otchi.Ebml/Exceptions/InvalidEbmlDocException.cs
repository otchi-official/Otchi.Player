using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class InvalidEbmlDocException: DecodeException
    {
        public InvalidEbmlDocException() { }

        public InvalidEbmlDocException(string message)
            : base(message) { }

        public InvalidEbmlDocException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}