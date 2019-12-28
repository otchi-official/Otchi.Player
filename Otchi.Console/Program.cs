using System;
using System.IO;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Tags;
using System.Threading;
using System.Threading.Tasks;
using Otchi.Core;

namespace Otchi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var path =
                @"C:\Users\paravicinij\source\repos\Otchi.Player\Otchi.App\bin\Debug\netcoreapp3.1\Downloads\[HorribleSubs] Ore wo Suki nano wa Omae dake ka yo - 01 [1080p].mkv";
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            var file1 = File.OpenRead(path);
            var buffer = new byte[1000000000];
            file1.Read(buffer, 0, 1000000000);
            watch1.Stop();
            System.Console.WriteLine(watch1.Elapsed);

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            var file2 = File.OpenRead(path);
            var buffer2 = new byte[1000000000];
            for (int i = 0; i < 1000000000; i += 1)
            {
                file2.Read(buffer2, i, 1);
            }
            watch2.Stop();
            System.Console.WriteLine(watch2.Elapsed);
            /*var manager = new StreamManager(
                "magnet:?xt=urn:btih:TJM7HROVMEEQNACMMY6JYVCQ5VW2RIK5&tr=http://nyaa.tracker.wf:7777/announce&tr=udp://tracker.coppersurfer.tk:6969/announce&tr=udp://tracker.internetwarriors.net:1337/announce&tr=udp://tracker.leechersparadise.org:6969/announce&tr=udp://tracker.opentrackr.org:1337/announce&tr=udp://open.stealth.si:80/announce&tr=udp://p4p.arenabg.com:1337/announce&tr=udp://mgtracker.org:6969/announce&tr=udp://tracker.tiny-vps.com:6969/announce&tr=udp://peerfect.org:6969/announce&tr=http://share.camoe.cn:8080/announce&tr=http://t.nyaatracker.com:80/announce&tr=https://open.kickasstracker.com:443/announce");
            manager.Start().Wait();
            Thread.Sleep(1000000);
            manager.ShutDown().Wait();
            */
        }
    }
}
