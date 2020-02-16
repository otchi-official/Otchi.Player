using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Otchi.Core;
using Otchi.Core.EventArgs;

namespace Otchi.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StreamManager _manager;
        public MainWindow()
        {
            InitializeComponent();
            _manager = new StreamManager(
                new Uri("magnet:?xt=urn:btih:T3UHFHG2ICAXLX53K2HI5ZNELJQUKH6G&tr=http://nyaa.tracker.wf:7777/announce&tr=udp://tracker.coppersurfer.tk:6969/announce&tr=udp://tracker.internetwarriors.net:1337/announce&tr=udp://tracker.leechersparadise.org:6969/announce&tr=udp://tracker.opentrackr.org:1337/announce&tr=udp://open.stealth.si:80/announce&tr=udp://p4p.arenabg.com:1337/announce&tr=udp://mgtracker.org:6969/announce&tr=udp://tracker.tiny-vps.com:6969/announce&tr=udp://peerfect.org:6969/announce&tr=http://share.camoe.cn:8080/announce&tr=http://t.nyaatracker.com:80/announce&tr=https://open.kickasstracker.com:443/announce", UriKind.Absolute));
            _manager.StreamLoaded += ManagerOnStreamLoaded;
            Task.Run(async () =>
            {
                await _manager.Start().ConfigureAwait(false);
            });
        }

        private void ManagerOnStreamLoaded(object? sender, StreamLoadedEventArgs e)
        {
            VideoPlayer.Play(_manager.FullPath);
        }
    }
}
