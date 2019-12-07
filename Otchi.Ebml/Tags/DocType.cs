using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class DocType : StringElement
    {
        internal DocType(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.DocTypeId;
        public override string Name => "DocType";
        public override Path Path => "1*1(\\EBML\\DocType)";
        public override bool ValidateValue => Value.Length > 0;
        public override string Description =>
            "A string that describes and identifies the content of the EBML Body that follows this EBML Header.";
    }

    public class DocTypeFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.DocTypeId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new DocType(dataSize, position, parent);
        }
    }
}