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
        public async Task<EbmlDocument> ParseDocument(bool decode = true)
        {
            EbmlHead? head = null;
            MasterElement? body = null;
            await foreach (var element in ParseRoots())
            {
                if (element is EbmlHead headElement)
                {
                    if (decode)
                        await headElement.Decode(this).ConfigureAwait(false);
                    head = headElement;
                }
                else
                {
                    if (decode)
                        await element.Decode(this).ConfigureAwait(false);
                    body = element;
                }
            }

            if (head == null || body == null)
                throw new InvalidEbmlDocException(ExceptionsResourceManager.ResourceManager.GetString("InvalidEbmlFile", CultureInfo.CurrentCulture));

            return new EbmlDocument(head, body);
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

            long position = 0;

            // TODO: Improve Exceptions.

            while (!DataAccessor.Done)
            {
                EbmlElement? element;
                try
                {
                    var readOperation = await ParseElementAt(position).ConfigureAwait(false);
                    element = readOperation.Value;
                    position = readOperation.Position;
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

                yield return (MasterElement)element;
            }
        }

        public async Task<ReadOperation<EbmlElement?>> ParseElementAt(long position, EbmlElement? parent = null)
        {
            var idReadOperation = await ParseIdAt(position);
            var dataReadOperation = await ParseVintAt(idReadOperation.Position);

            var factory = FactoryList.GetValueOrDefault(idReadOperation.Value.Size);
            var element = factory?.Create(dataReadOperation.Value, position, parent);

            return new ReadOperation<EbmlElement?>(
                dataReadOperation.Position + dataReadOperation.Value.DataSize, element);
        }


        #region VInt Parsing

        public async Task<ReadOperation<VInt>> ParseVintAt(long position)
        {
            const int byteSize = 8;
            const int vintDataSizePerByte = byteSize - 1;
            var buffer = new byte[byteSize];
            try
            {
                await DataAccessor.ReadAsync(buffer, 0, 1, position).ConfigureAwait(false);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                throw new DecodeException(exception.Message);
            }
            
            if (buffer[0] == 0)
                throw new FileNotLoadedException($"VInt at position {position:X} was not initialized");

            var vintWidth = vintDataSizePerByte - buffer[0].GetMostSignificantBit();

            // Validate range. It actually can't be outside this range, therefore its just a temporary assert
            Debug.Assert(vintWidth <= vintDataSizePerByte && vintWidth >= 0, "Invalid Vint Width");

            await DataAccessor.ReadAsync(buffer, 1, vintWidth, position+1).ConfigureAwait(false);

            if (buffer.All(x => x == 0))
                throw new FileNotLoadedException($"VInt at position {position:X} was not initialized");

            buffer = Utility.ConvertEndiannes(buffer, vintWidth + 1);

            var value = BitConverter.ToInt64(buffer, 0);
            var vint = VInt.FromValue(value);
            return new ReadOperation<VInt>(position + vintWidth + 1, vint);
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
        public async Task<ReadOperation<VInt>> ParseIdAt(long position)
        {
            var vint = await ParseVintAt(position).ConfigureAwait(false);
            // TODO: Seems kinda stupid to me to call a function which sole purpose is to throw exceptions.
            ValidateId(vint.Value);
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