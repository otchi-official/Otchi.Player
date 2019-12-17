using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class FileNotLoadedException: DecodeException
    {
        public FileNotLoadedException() { }

        public FileNotLoadedException(string message)
            : base(message) { }

        public FileNotLoadedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}