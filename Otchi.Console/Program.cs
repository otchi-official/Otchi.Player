using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Tags;
using System.Threading;
using System.Threading.Tasks;

namespace Otchi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new EbmlParser(new FileDataAccessor(@"C:\Users\paravicinij\Downloads\test2.mkv"),
                EbmlFactories.AllEbmlHeadFactories);
            var head = parser.ParseElementAt(0).Result.Value as EbmlHead;
            var task2 = Task.Factory.StartNew(async () =>
            {
                Thread.CurrentThread.Name = "Task 2";
                await foreach (var element in head.GetAsyncEnumerable(parser))
                {
                    await (element?.Decode(parser) ?? Task.CompletedTask);
                    await Task.Delay(50);
                }
                System.Console.WriteLine("Task 2 done");
            });

            var task1 = Task.Factory.StartNew(async () =>
            {
                Thread.CurrentThread.Name = "Task 1";
                await Task.Delay(100);
                await head.Decode(parser);
                System.Console.WriteLine("Task1 done");
            });

            Task.WaitAll(task1, task2);
            System.Console.WriteLine(head);
            Thread.Sleep(5000);

            /*
            var manager = new TorrentManager(
                "magnet:?xt=urn:btih:TJM7HROVMEEQNACMMY6JYVCQ5VW2RIK5&tr=http://nyaa.tracker.wf:7777/announce&tr=udp://tracker.coppersurfer.tk:6969/announce&tr=udp://tracker.internetwarriors.net:1337/announce&tr=udp://tracker.leechersparadise.org:6969/announce&tr=udp://tracker.opentrackr.org:1337/announce&tr=udp://open.stealth.si:80/announce&tr=udp://p4p.arenabg.com:1337/announce&tr=udp://mgtracker.org:6969/announce&tr=udp://tracker.tiny-vps.com:6969/announce&tr=udp://peerfect.org:6969/announce&tr=http://share.camoe.cn:8080/announce&tr=http://t.nyaatracker.com:80/announce&tr=https://open.kickasstracker.com:443/announce",
                Path.Combine(Directory.GetCurrentDirectory(), "Downloads"));
            manager.Start().Wait();
            Thread.Sleep(1000000);
            manager.ShutDown().Wait();
            */
        }
    }
}
