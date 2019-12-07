using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class DocTypeExtensionVersion : UnsignedIntElement
    {
        internal DocTypeExtensionVersion(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.DocTypeExtensionVersionId;
        public override string Name => "DocTypeExtensionVersion";
        public override Path Path => "1*1(\\EBML\\DocTypeExtension\\Version)";
        public override bool ValidateValue => Value != 0;

        public override string Description =>
            "The version of the DocTypeExtension. " +
            "Different DocTypeExtensionVersion values of the same " +
            "DocType+DocTypeVersion+DocTypeExtensionName tuple " +
            "MAY contain completely different sets of extra Elements. " +
            "An EBML Reader MAY support multiple versions of the same DocTypeExtension, " +
            "only one or none.";
    }

    public class DocTypeExtensionVersionFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.DocTypeExtensionVersionId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new DocTypeExtensionVersion(dataSize, position, parent);
        }
    }
}