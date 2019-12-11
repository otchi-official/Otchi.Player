using System;
using System.Globalization;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Tags;

namespace Otchi.Ebml
{
    public class EbmlDocument
    {
        public EbmlHead Head { get; }

        public MasterElement Body { get; }

        public EbmlDocument(EbmlHead head, MasterElement body)
        {
            Head = head;
            Body = body;
        }

        public override string ToString()
        {
            return $"EBML Document: \n{Head}\n{Body}";
        }
    }
}
