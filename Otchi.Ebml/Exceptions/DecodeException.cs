using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class DecodeException : IOException
    {
        public DecodeException() { }

        public DecodeException(string message)
            : base(message) { }

        public DecodeException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}