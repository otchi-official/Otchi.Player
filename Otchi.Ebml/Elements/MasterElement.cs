using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Elements
{
    public abstract class MasterElement : EbmlElement, IReadOnlyDictionary<long, EbmlElement>, IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        #region Fields

        private readonly SortedList<long, EbmlElement> _children = new SortedList<long, EbmlElement>();
        private long _parserPosition = 0;
        private readonly SemaphoreSlim _parserSemaphoreSlim = new SemaphoreSlim(1, 1);

        #endregion

        #region Properties

        public sealed override EbmlType Type => EbmlType.Master;

        #endregion

        #region Constructors

        protected MasterElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        #endregion

        #region Decoding

        public override Task Decode(EbmlParser parser, bool forceDecode = false)
        {
            return Decode(parser, forceDecode, true);
        }

        public async Task Decode(EbmlParser parser, bool force, bool recursive)
        {
            if (Decoded && !force) return;
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            if (parser.DataAccessor == null) throw new InvalidOperationException(
                ExceptionsResourceManager.ResourceManager.GetString("InvalidDecodeState", CultureInfo.CurrentCulture));

            if (DataPosition >= EndPosition)
            {
                Console.WriteLine($"Element {this} contains no children");
                return;
            }

            await _parserSemaphoreSlim.WaitAsync().ConfigureAwait(false);

            try
            {
                _parserPosition = DataPosition;
                while (_parserPosition < EndPosition)
                {
                    var element = await parser.ParseElementAt(_parserPosition, Parent).ConfigureAwait(false);
                    if (element == null)
                    {
                        _parserPosition = parser.DataAccessor.Position;
                        continue;
                    }
                    if (recursive) await element.Decode(parser).ConfigureAwait(false);
                    _parserPosition = parser.DataAccessor.Position;
                    InsertElement(element);
                }

                Decoded = true;
            }
            finally
            {
                _parserSemaphoreSlim.Release(1);
            }
        }

        public async Task<EbmlElement?> DecodeNextChild(EbmlParser parser)
        {
            if (parser is null) throw new ArgumentNullException(nameof(parser));

            var lastChild = _children.LastOrDefault().Value;
            if (lastChild.Position > EndPosition)
                throw new EndOfMasterException(ExceptionsResourceManager.ResourceManager.GetString("NoChildLeft", CultureInfo.CurrentCulture));

            var index = lastChild.EndPosition;
            var child = await parser.ParseElementAt(index).ConfigureAwait(false);
            if (child != null)
                InsertElement(child);
            return child;
        }

        public async Task<EbmlElement?> DecodeChildAt(EbmlParser parser, long index)
        {
            if (parser is null) throw new ArgumentNullException(nameof(parser));
            if (index < DataPosition || index >= EndPosition) throw new ArgumentOutOfRangeException(nameof(index));

            var child = await parser.ParseElementAt(index).ConfigureAwait(false);
            if (child != null) InsertElement(child);
            return child;
        }

        #endregion

        public async IAsyncEnumerable<EbmlElement?> GetAsyncEnumerable(EbmlParser parser)
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            var position = DataPosition;
            while (position < EndPosition)
            {
                EbmlElement? child;
                if (_children.ContainsKey(position))
                    child = _children[position];
                else
                    child = await DecodeChildAt(parser, position).ConfigureAwait(false);

                position = child?.EndPosition ?? parser.DataAccessor.Position;
                yield return child;
            }
        }

        public async Task<T> TryGetChild<T>(EbmlParser parser) where T : EbmlElement
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            await foreach (var child in GetAsyncEnumerable(parser))
            {
                if (child is T element)
                {
                    return element;
                }
            }

            throw new ParseFailedException("Could not parse child");
        }

        private void InsertElement(EbmlElement childElement)
        {
            if (childElement == null) throw new ArgumentNullException(nameof(childElement));
            if (childElement.Position < Position || childElement.EndPosition > EndPosition)
                throw new ArgumentOutOfRangeException(ExceptionsResourceManager.ResourceManager.GetString("ChildOutOfRange", CultureInfo.CurrentCulture));

            if (childElement.Path.ParentPath == Name)
            {
                childElement.Parent = this;
                _children.Add(childElement.Position, childElement);
            }
            else
            {
                var targetChild = _children.FirstOrDefault(pair => pair.Key < childElement.Position).Value;

                if (targetChild is MasterElement master)
                {
                    try
                    {
                        master.InsertElement(childElement);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw new ParseFailedException("Either the document has not been loaded yet, or the document is constructed incorrectly");
                    }
                }
                else
                {
                    throw new InvalidEbmlTypeException(ExceptionsResourceManager.ResourceManager.GetString("ParentNotParsed", CultureInfo.CurrentCulture));
                }
            }
        }

        #region Logging

        public string ToString(int indent)
        {
            var tabs = string.Concat(Enumerable.Repeat("\t", indent));
            var result = $"{tabs}{Name} - Master:\n";
            if (_children == null)
            {
                result += $"{tabs}\t<NULL>";
                return result;
            }

            foreach (var element in _children)
            {
                if (element.Value.Type == EbmlType.Master)
                    result += ((MasterElement)element.Value).ToString(indent + 1);

                else
                {
                    result += $"{tabs}\t{element}\n";
                }
            }

            return result;
        }

        public override string ToString()
        {
            return ToString(0);
        }

        #endregion

        #region IDictionary Implementation

        public int Count => _children.Count;
        public EbmlElement this[long key] => _children[key];
        public IEnumerable<long> Keys => _children.Keys;
        public IEnumerable<EbmlElement> Values => _children.Values;

        public bool ContainsKey(long key) => _children.ContainsKey(key);
        public IEnumerator<KeyValuePair<long, EbmlElement>> GetEnumerator() => _children.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public bool TryGetValue(long key, out EbmlElement value) => _children.TryGetValue(key, out value);

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _parserSemaphoreSlim.Dispose();
            }
        }

        #endregion
    }
}