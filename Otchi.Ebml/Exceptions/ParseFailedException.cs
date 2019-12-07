using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class ParseFailedException: DecodeException
    {
        public ParseFailedException() { }

        public ParseFailedException(string message)
            : base(message) { }

        public ParseFailedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}