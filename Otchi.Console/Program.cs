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
            
            var manager = new StreamManager(
                "magnet:?xt=urn:btih:TJM7HROVMEEQNACMMY6JYVCQ5VW2RIK5&tr=http://nyaa.tracker.wf:7777/announce&tr=udp://tracker.coppersurfer.tk:6969/announce&tr=udp://tracker.internetwarriors.net:1337/announce&tr=udp://tracker.leechersparadise.org:6969/announce&tr=udp://tracker.opentrackr.org:1337/announce&tr=udp://open.stealth.si:80/announce&tr=udp://p4p.arenabg.com:1337/announce&tr=udp://mgtracker.org:6969/announce&tr=udp://tracker.tiny-vps.com:6969/announce&tr=udp://peerfect.org:6969/announce&tr=http://share.camoe.cn:8080/announce&tr=http://t.nyaatracker.com:80/announce&tr=https://open.kickasstracker.com:443/announce");
            manager.Start().Wait();
            Thread.Sleep(1000000);
            manager.ShutDown().Wait();
            
        }
    }
}
