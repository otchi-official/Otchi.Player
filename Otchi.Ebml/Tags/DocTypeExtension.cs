using System.Linq;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class DocTypeExtension : MasterElement
    {
        internal DocTypeExtension(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.DocTypeExtensionId;
        public override string Name => "DocTypeExtension";
        public override Path Path => "0*(\\EBML\\DocTypeExtension)";

        public override string Description =>
            "A DocTypeExtension adds extra Elements to the main DocType+DocTypeVersion tuple it's attached to. " +
            "An EBML Reader MAY know these extra Elements and how to use them. " +
            "A DocTypeExtension MAY be used to iterate between experimental Elements " +
            "before they are integrated in a regular DocTypeVersion. " +
            "Reading one DocTypeExtension version of a DocType+DocTypeVersion " +
            "tuple doesn't imply one should be able to read upper versions of this DocTypeExtension.";

        public DocTypeExtension? DocTypeExtensionElement =>
            (from value in this where value.Value.Id == EbmlIds.DocTypeExtensionId select value.Value).FirstOrDefault() as DocTypeExtension;

        public DocTypeExtensionName? DocTypeExtensionNameElement =>
            (from value in this where value.Value.Id == EbmlIds.DocTypeExtensionNameId select value.Value).FirstOrDefault() as DocTypeExtensionName;

        public DocTypeExtensionVersion? DocTypeExtensionVersionElement =>
            (from value in this where value.Value.Id == EbmlIds.DocTypeExtensionVersionId select value.Value).FirstOrDefault() as DocTypeExtensionVersion;

        
        public string DocTypeExtensionName => DocTypeExtensionNameElement?.Value ?? string.Empty;
        public ulong DocTypeExtensionVersion => DocTypeExtensionVersionElement?.Value ?? 0;
    }

    public class DocTypeExtensionFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.DocTypeExtensionId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new DocTypeExtension(dataSize, position, parent);
        }
    }
}