using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Otchi.Core;
using Otchi.Ebml;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Matroska.Factories;
using Otchi.Matroska.Tags;

namespace Otchi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Meh().Wait();

            /*
            var manager = new TorrentManager(
                "magnet:?xt=urn:btih:TJM7HROVMEEQNACMMY6JYVCQ5VW2RIK5&tr=http://nyaa.tracker.wf:7777/announce&tr=udp://tracker.coppersurfer.tk:6969/announce&tr=udp://tracker.internetwarriors.net:1337/announce&tr=udp://tracker.leechersparadise.org:6969/announce&tr=udp://tracker.opentrackr.org:1337/announce&tr=udp://open.stealth.si:80/announce&tr=udp://p4p.arenabg.com:1337/announce&tr=udp://mgtracker.org:6969/announce&tr=udp://tracker.tiny-vps.com:6969/announce&tr=udp://peerfect.org:6969/announce&tr=http://share.camoe.cn:8080/announce&tr=http://t.nyaatracker.com:80/announce&tr=https://open.kickasstracker.com:443/announce",
                Path.Combine(Directory.GetCurrentDirectory(), "Downloads"));
            manager.Start().Wait();
            Thread.Sleep(1000000);
            manager.ShutDown().Wait();
            */
        }

        static async Task Meh()
        {
            var parser = new EbmlParser(new FileDataAccessor(
                    @"F:\repos\Otchi.Core\Otchi.Core.Console\bin\Debug\netcoreapp3.0\Downloads\[HorribleSubs] Radiant S2 - 06 [1080p].mkv"),
                EbmlFactories.Merge(new[] { EbmlFactories.AllEbmlHeadFactories, MatroskaFactories.AllMatroskaFactories }));
            EbmlDocument? document = null;
            try
            {
                document = parser.ParseDocument(false).Result;
                document.Head.Decode(parser, true, true).Wait();
                var seekHead = await document.Body.TryGetChild<SeekHead>(parser);
                await seekHead.Decode(parser);
            }
            catch (DecodeException)
            {
                System.Console.WriteLine($"Failed at: {parser.DataAccessor.Position}");
            }

            System.Console.WriteLine(document);
        }
    }
}
