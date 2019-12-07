using System.IO;
using System.Threading.Tasks;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;
using Path = Otchi.Ebml.Types.Path;

namespace Otchi.Ebml.Elements
{
    public abstract class EbmlElement
    {
        public bool Decoded { get; protected set; }

        protected EbmlElement(VInt dataSize, long position, EbmlElement? parent = null)
        {
            DataSize = dataSize;
            Position = position;
            Parent = parent;
        }

        #region Properties
        public VInt DataSize { get; }
        public long Position { get; }
        public EbmlElement? Parent { get; set; }
        public EbmlElement RootElement
        {
            get
            {
                var parent = Parent;
                while (parent?.Parent != null)
                {
                    parent = parent.Parent;
                }

                return parent ?? this;
            }
        }

        #endregion

        #region Abstract Properties

        public abstract EbmlType Type { get; }
        public abstract VInt Id { get; }
        public abstract string Name { get; }
        public abstract Path Path { get; }

        #endregion

        #region Virtual Properties

        public virtual string Description => string.Empty;
        public virtual bool ValidateValue => true;

        #endregion

        #region Computed Properties

        public long Size => Id.ByteSize + DataSize.ByteSize + DataSize.DataSize;
        public long DataPosition => Position + Id.ByteSize + DataSize.ByteSize;
        public long EndPosition => Position + Size;

        #endregion

        #region Methods

        public abstract Task Decode(EbmlParser parser, bool forceDecode = false);

        public override string ToString()
        {
            return $"{Name} - {Type}: <ENCODED>";
        }
 
        #endregion

    }
}