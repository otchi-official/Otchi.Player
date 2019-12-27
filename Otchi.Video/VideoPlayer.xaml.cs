using System;
using System.Windows;
using System.Windows.Controls;
using LibVLCSharp.Shared;

namespace Otchi.Video
{

    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : UserControl
    {
        private readonly LibVLC _libVlc;
        private readonly MediaPlayer _mediaPlayer;

        public VideoPlayer()
        {
            InitializeComponent();
            Core.Initialize();
            _libVlc = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVlc);
            VideoView.MediaPlayer = _mediaPlayer;
        }

        public void Play(string name)
        {
            using var media = new Media(_libVlc, name);
            _mediaPlayer.Play(media);
        }

        private void Fullscreen_Clicked(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            // TODO: Maybe throw an error, but don't log into main console.
            if (window is null)
            {
                Console.WriteLine("Window is unexpectedly null");
                return;
            }
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
                window.WindowStyle = WindowStyle.SingleBorderWindow;
            }
            else
            {
                window.WindowStyle = WindowStyle.None;
                window.WindowState = WindowState.Maximized;
            }
        }
    }
}
