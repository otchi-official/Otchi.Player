using System;
using System.Collections.Generic;
using System.Linq;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Factories
{
    public abstract class EbmlElementFactory
    {
        #region Static Factory Initialization

        private static readonly Lazy<Dictionary<long, EbmlElementFactory>> FactoriesLazy = new Lazy<Dictionary<long, EbmlElementFactory>>(
            () =>
            {
                var factories = new Dictionary<long, EbmlElementFactory>();
                var assembly = typeof(EbmlElementFactory).Assembly;
                var subclasses =
                    from type in assembly.GetTypes()
                    where type.IsSubclassOf(typeof(EbmlElement)) && !type.IsAbstract
                    select type;

                foreach (var subclass in subclasses)
                {
                    var type = subclass.Assembly.GetType($"{subclass.FullName}Factory");
                    if (type == null)
                        continue;

                    // Create the Factory
                    var factory = (EbmlElementFactory) Activator.CreateInstance(type);
                    factories[factory.Id.Size] = factory;
                }

                return factories;
            });

        public static readonly Dictionary<long, EbmlElementFactory> Factories = FactoriesLazy.Value;
        public static EbmlElementFactory GetFactory(long id)
        {
            FactoriesLazy.Value.TryGetValue(id, out var factory);
            return factory;
        }
        public static EbmlElementFactory GetFactory(VInt id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return GetFactory(id.Size);
        }
        public static bool RegisterFactory(long id, EbmlElementFactory factory)
        {
            if (FactoriesLazy.Value.ContainsKey(id))
                return false;
            FactoriesLazy.Value[id] = factory;
            return true;
        }
        public static bool UnregisterFactory(long id)
        {
            return FactoriesLazy.Value.Remove(id);
        }

        #endregion

        public abstract VInt Id { get; }
        public abstract EbmlElement Create(VInt dataSize, long position, EbmlElement? parent);
    }
}