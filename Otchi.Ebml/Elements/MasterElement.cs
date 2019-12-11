using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        #region Fields

        private readonly SemaphoreSlim _insertSemaphore = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _decodeSemaphore = new SemaphoreSlim(1, 1);
        private readonly SortedList<long, EbmlElement> _children = new SortedList<long, EbmlElement>();

        #endregion

        #region Properties

        public sealed override EbmlType Type => EbmlType.Master;

        #endregion

        #region Constructors

        protected MasterElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
            _nextDecodePosition = DataPosition;
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
            var position = DataPosition;
            while (position < EndPosition)
            {
                var elementReadOperation = await parser.ParseElementAt(position, Parent).ConfigureAwait(false);
                if (recursive) 
                    await (elementReadOperation.Value?.Decode(parser) ?? Task.CompletedTask).ConfigureAwait(false);
                position = elementReadOperation.Position;
            }

            Decoded = true;
        }

        public async Task<ReadOperation<EbmlElement?>> DecodeChildAt(EbmlParser parser, long index)
        {
            // All decoding operations will come through here. Hence we lock this function so we can synchronize all calls related to decoding an element.
            await _decodeSemaphore.WaitAsync();
            try
            {
                if (parser is null) throw new ArgumentNullException(nameof(parser));
                if (index < DataPosition || index >= EndPosition) throw new ArgumentOutOfRangeException(nameof(index));

                // Return the parsed element if it already exists.
                var child = _children[index];
                if (child != null)
                {
                    return new ReadOperation<EbmlElement?>(child.EndPosition, child);
                }


                var childReadOperation = await parser.ParseElementAt(index).ConfigureAwait(false);
                if (childReadOperation.Value != null)
                    await InsertElement(childReadOperation.Value);
                return childReadOperation;
            }
            finally
            {
                _decodeSemaphore.Release();
            }
        }

        #endregion

        public async IAsyncEnumerable<EbmlElement?> GetAsyncEnumerable(EbmlParser parser)
        {
            if (parser == null) throw new ArgumentNullException(nameof(parser));

            var position = DataPosition;
            while (position < EndPosition)
            {
                var childReadOperation = await DecodeChildAt(parser, position).ConfigureAwait(false);

                position = childReadOperation.Position;
                yield return childReadOperation.Value;
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

        private async Task InsertElement(EbmlElement childElement)
        {
            await _insertSemaphore.WaitAsync();
            try
            {
                Debug.Assert(childElement != this, "childElement != this");
                if (childElement == null) throw new ArgumentNullException(nameof(childElement));
                if (childElement.Position < Position || childElement.EndPosition > EndPosition)
                    throw new ArgumentOutOfRangeException(
                        ExceptionsResourceManager.ResourceManager.GetString("ChildOutOfRange",
                            CultureInfo.CurrentCulture));

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
                            await master.InsertElement(childElement);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            throw new ParseFailedException(
                                "Either the document has not been loaded yet, or the document is constructed incorrectly");
                        }
                    }
                    else
                    {
                        throw new InvalidEbmlTypeException(
                            ExceptionsResourceManager.ResourceManager.GetString("ParentNotParsed",
                                CultureInfo.CurrentCulture));
                    }
                }
            }
            finally
            {
                _insertSemaphore.Release();
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
            if (!disposing) return;
            _decodeSemaphore.Dispose();
            _insertSemaphore.Dispose();
        }

        #endregion
    }
}