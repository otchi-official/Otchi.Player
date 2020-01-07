using System;
using System.Diagnostics;
using System.IO;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Tags;
using System.Threading;
using System.Threading.Tasks;
using Otchi.Core;
using Otchi.Matroska.Factories;

namespace Otchi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            TestReadingSpeed().Wait();
            stopwatch.Stop();
            System.Console.WriteLine(stopwatch.Elapsed);
        }

        private static async Task TestReadingSpeed()
        {
            var path =
                @"C:\Users\jorge\Downloads\test1.mkv";
            using var dataAccessor = new FileDataAccessor(path);
            var parser = new EbmlParser(dataAccessor, EbmlFactories.Merge(new []
            {
                EbmlFactories.AllEbmlHeadFactories,
                MatroskaFactories.AllMatroskaFactories
            }));
            var doc = await parser.ParseDocument().ConfigureAwait(false);
            System.Console.WriteLine(doc);
        }
    }
}
