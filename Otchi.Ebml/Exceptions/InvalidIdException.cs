using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class InvalidIdException: DecodeException
    {
        public InvalidIdException() { }

        public InvalidIdException(string message)
            : base(message) { }

        public InvalidIdException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}