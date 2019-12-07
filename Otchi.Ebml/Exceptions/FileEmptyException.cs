using System;
using System.IO;

namespace Otchi.Ebml.Exceptions
{
    public class FileEmptyException: IOException
    {
        public FileEmptyException() { }

        public FileEmptyException(string message)
            : base(message) { }

        public FileEmptyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}