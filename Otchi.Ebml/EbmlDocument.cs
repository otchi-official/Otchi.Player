using System;
using System.Globalization;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Tags;

namespace Otchi.Ebml
{
    public class EbmlDocument
    {
        public EbmlHead? Head { get; set; }

        public MasterElement? Body { get; set; }

        public EbmlDocument() {}

        public EbmlDocument(EbmlHead head, MasterElement body)
        {
            Head = head;
            Body = body;
        }

        /*public void InsertElement(EbmlElement element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            if (Body is null || Head is null) throw new InvalidOperationException("Document not initialized");
            if (element.Position < 0 || element.Position > Body.Position + Body.Size) throw new ArgumentOutOfRangeException(nameof(element));

            if (element.Position < Head.Position)
                Head.InsertElement(element);
            else
                Body.InsertElement(element);

        }*/

        public override string ToString()
        {
            return $"EBML Document: \n{Head}\n{Body}";
        }
    }
}
