using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class InvalidEbmlTypeException : DecodeException
    {
        public InvalidEbmlTypeException() { }

        public InvalidEbmlTypeException(string message)
            : base(message) { }

        public InvalidEbmlTypeException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}