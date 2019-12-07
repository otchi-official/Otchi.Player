using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class FileClosedException: IOException
    {
        public FileClosedException() { }

        public FileClosedException(string message)
            : base(message) { }

        public FileClosedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}