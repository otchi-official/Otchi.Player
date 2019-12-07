using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Otchi.BitOperations;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Tags;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Parsers
{
    /// <summary>
    /// A generalized parser for any Ebml Document.
    /// All of its content will be parsed asynchronously.
    /// </summary>
    public class EbmlParser
    {

        private Dictionary<long, EbmlElementFactory> FactoryList { get; }

        public bool ShouldLog { get; set; } = false;

        public IParserDataAccessor DataAccessor { get; }

        /// <summary>
        /// Constructs a new Parser from a path to a valid ebml file.
        /// </summary>
        /// <param name="dataAccessor">The path to the valid ebml file.</param>
        /// <param name="factoryList">A dictionary of factories that should be used to decode the file.</param>
        public EbmlParser(IParserDataAccessor dataAccessor, Dictionary<long, EbmlElementFactory>? factoryList = null)
        {
            DataAccessor = dataAccessor;
            FactoryList = factoryList ?? EbmlElementFactory.Factories;
        }

        /// <summary>
        /// Parses the entire Document or until it reaches a dead end.
        /// </summary>
        /// <returns>The document for the path. Make sure to await it.</returns>
        public async Task<EbmlDocument?> ParseDocument(bool decode = true)
        {
            var document = new EbmlDocument();
            await foreach (var element in ParseRoots())
            {
                if (element is EbmlHead head)
                {
                    if (decode)
                        await head.Decode(this).ConfigureAwait(false);
                    document.Head = head;
                }
                else
                {
                    if (decode)
                        await element.Decode(this).ConfigureAwait(false);
                    document.Body = element;
                }
            }

            if (document.Head == null || document.Body == null)
                throw new InvalidEbmlDocException(ExceptionsResourceManager.ResourceManager.GetString("InvalidEbmlFile", CultureInfo.CurrentCulture));

            return document;
        }

        /// <summary>
        /// Parses all Root elements of the Matroska File.
        /// <para>
        /// It takes care of initialization of the FileStream. Meaning it can be called anytime.
        /// But if the file stream was initialized beforehand, it will be overriden.
        /// </para>
        /// <exception cref="InvalidEbmlTypeException">
        /// Thrown if a root element is not a valid master element
        /// </exception>
        /// </summary>
        /// <returns></returns>
        public async IAsyncEnumerable<MasterElement> ParseRoots()
        {
            if (DataAccessor.Length == 0) 
                throw new FileEmptyException(ExceptionsResourceManager.ResourceManager.GetString(
                    "TriedToParseEmptyFile",
                    CultureInfo.CurrentCulture));
            DataAccessor.Position = 0;
            while (!DataAccessor.Done)
            {
                EbmlElement? element;
                try
                {
                    element = await ParseNextElement().ConfigureAwait(false);
                }
                catch (FileNotLoadedException)
                {
                    break;
                }
                catch (InvalidIdException)
                {
                    break;
                }

                if (element == null)
                {
                    throw new InvalidEbmlDocException(ExceptionsResourceManager.ResourceManager.GetString(
                        "MissingRootFactory",
                        CultureInfo.CurrentCulture));
                }

                if (element.Type != EbmlType.Master)
                    throw new InvalidEbmlDocException(ExceptionsResourceManager.ResourceManager.GetString(
                        "InvalidRootType",
                        CultureInfo.CurrentCulture));
                DataAccessor.Position = element.EndPosition;
                yield return (MasterElement)element;
            }
        }

        /// <summary>
        /// Parses the next element in the file stream.
        /// </summary>
        /// <exception cref="FileNotLoadedException">
        /// Thrown if part of the next element has not been downloaded yet.
        /// </exception>
        /// <returns>An asynchronous Task to which will yield the next Element.</returns>
        public async Task<EbmlElement?> ParseNextElement(EbmlElement? parent = null)
        {
            var position = DataAccessor.Position;
            // Throws FileNotLoadedException if the file has not been loaded at the position
            var id = await ParseNextId().ConfigureAwait(false);
            // Throws FileNotLoadedException if the file has not been loaded at the position
            var dataSize = await ParseNextVInt().ConfigureAwait(false);

            var factory = FactoryList.GetValueOrDefault(id.Size);
            var element = factory?.Create(dataSize, position, parent);

            if (element != null) return element;

            if (ShouldLog)
                ConsoleExtension.WriteWarning($"No factory found for element {id.Size:X} at position: {position}");
            DataAccessor.Position = position + dataSize.ByteSize + dataSize.DataSize + id.ByteSize;
            return null;
        }

        public async Task<EbmlElement?> ParseElementAt(long offset, EbmlElement? parent = null)
        {
            DataAccessor.Position = offset;
            return await ParseNextElement(parent).ConfigureAwait(false);
        }


        #region VInt Parsing

        public async Task<VInt> ParseNextVInt()
        {

            const int byteSize = 8;
            const int vintDataSizePerByte = byteSize - 1;
            var buffer = new byte[byteSize];
            await DataAccessor.ReadAsync(buffer, 0, 1).ConfigureAwait(false);
            if (buffer[0] == 0)
                throw new FileNotLoadedException($"VInt at position {DataAccessor.Position - 1:X} was not initialized");

            var vintWidth = vintDataSizePerByte - buffer[0].GetMostSignificantBit();

            // Validate range. It actually can't be outside this range, therefore its just a temporary assert
            Debug.Assert(vintWidth <= vintDataSizePerByte && vintWidth >= 0, "Invalid Vint Width");

            await DataAccessor.ReadAsync(buffer, 1, vintWidth).ConfigureAwait(false);

            if (buffer.All(x => x == 0))
                throw new FileNotLoadedException($"VInt at position {DataAccessor.Position - 1 - vintWidth:X} was not initialized");

            buffer = Utility.ConvertEndiannes(buffer, vintWidth + 1);

            var value = BitConverter.ToInt64(buffer, 0);
            return VInt.FromValue(value);
        }

        /// <summary>
        /// A specialized form of parsing the next VInt. This validates the vint to make sure its a valid Id.
        /// </summary>
        /// <remarks>
        /// <see href="https://github.com/cellar-wg/ebml-specification/blob/master/specification.markdown#element-id">
        /// See this link for more information
        /// </see>
        /// </remarks>
        /// <returns></returns>
        public async Task<VInt> ParseNextId()
        {
            var vint = await ParseNextVInt().ConfigureAwait(false);
            ValidateId(vint);
            return vint;
        }

        /// <summary>
        /// Validate a VInt to make sure its a valid Id.
        /// It does not return a boolean indicating whether it was a correct id or not,
        /// moreover it throws an <see cref="InvalidDataException"/> if the Id is not valid.
        /// </summary>
        /// <param name="id">The variable integer to test.</param>
        /// <exception cref="InvalidDataException">Thrown if the id is not valid.</exception>
        public static void ValidateId(VInt id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (id.DataSize == 0)
                throw new InvalidIdException(
                    ExceptionsResourceManager.ResourceManager.GetString("DocNotInitialized", CultureInfo.CurrentCulture));
            if (id.Size.AreAllBitsSet())
                throw new InvalidIdException(
                    ExceptionsResourceManager.ResourceManager.GetString("DocNotInitialized", CultureInfo.CurrentCulture));

            for (var i = 7; i < id.MarkerPosition; i += 7)
            {
                if (id.DataSize < Math.Pow(2, i))
                    throw new InvalidIdException(
                        ExceptionsResourceManager.ResourceManager.GetString("DocNotInitialized", CultureInfo.CurrentCulture));
            }
        }

        #endregion



    }
}