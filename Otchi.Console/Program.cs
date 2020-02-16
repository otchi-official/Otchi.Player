using System;
using System.Diagnostics;
using System.IO;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Tags;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using Otchi.Core;
using Otchi.Matroska.Factories;

namespace Otchi.Console
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args) {
            var _manager = new StreamManager(
                new Uri("magnet:?xt=urn:btih:SQALL6ENDLW2G6O4MKMQUNHV2KHAPFQP&tr=http://nyaa.tracker.wf:7777/announce&tr=udp://tracker.coppersurfer.tk:6969/announce&tr=udp://tracker.internetwarriors.net:1337/announce&tr=udp://tracker.leechersparadise.org:6969/announce&tr=udp://tracker.opentrackr.org:1337/announce&tr=udp://open.stealth.si:80/announce&tr=udp://p4p.arenabg.com:1337/announce&tr=udp://mgtracker.org:6969/announce&tr=udp://tracker.tiny-vps.com:6969/announce&tr=udp://peerfect.org:6969/announce&tr=http://share.camoe.cn:8080/announce&tr=http://t.nyaatracker.com:80/announce&tr=https://open.kickasstracker.com:443/announce", UriKind.Absolute));
            _manager.Start();

            while (true)
            {
                
            }
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
