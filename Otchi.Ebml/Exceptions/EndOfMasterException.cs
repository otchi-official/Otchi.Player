using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class EndOfMasterException : DecodeException
    {
        public EndOfMasterException() { }

        public EndOfMasterException(string message)
            : base(message) { }

        public EndOfMasterException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}