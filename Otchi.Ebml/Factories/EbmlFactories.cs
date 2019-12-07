using System.Collections.Generic;
using System.Linq;
using Otchi.Ebml.Tags;

namespace Otchi.Ebml.Factories
{
    public static class EbmlFactories
    {
        private static readonly List<long> EbmlFactoriesIds = new List<long>
        {
            EbmlIds.EbmlHeadId.Size, EbmlIds.EbmlMaxIdLengthId.Size, EbmlIds.EbmlMaxSizeLengthId.Size,
            EbmlIds.EbmlReadVersionId.Size, EbmlIds.EbmlVersionId.Size
        };

        private static readonly List<long> DocTypeFactoriesIds = new List<long>
        {
            EbmlIds.DocTypeExtensionId.Size, EbmlIds.DocTypeExtensionNameId.Size, EbmlIds.DocTypeExtensionVersionId.Size,
            EbmlIds.DocTypeId.Size, EbmlIds.DocTypeVersionId.Size, EbmlIds.DocTypeReadVersionId.Size
        };

        public static Dictionary<long, EbmlElementFactory> EbmlElementFactories { get; } =
            FactoriesFromIds(EbmlFactoriesIds);

        public static Dictionary<long, EbmlElementFactory> DocTypeFactories { get; } =
            FactoriesFromIds(DocTypeFactoriesIds);

        public static Dictionary<long, EbmlElementFactory> AllEbmlHeadFactories { get; } =
            Merge(new List<Dictionary<long, EbmlElementFactory>> {EbmlElementFactories, DocTypeFactories});

        private static Dictionary<long, EbmlElementFactory> FactoriesFromIds(IEnumerable<long> factoryIds)
        {
            return (from factory in EbmlElementFactory.Factories
                    where factoryIds.Contains(factory.Key)
                    select factory).ToDictionary(t => t.Key, t => t.Value);
        }

        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(IEnumerable<Dictionary<TKey, TValue>> dictionaries)
        {
            return dictionaries.SelectMany(dict => dict)
                .ToLookup(pair => pair.Key, pair => pair.Value)
                .ToDictionary(group => group.Key, group => group.First());
        }
    }
}