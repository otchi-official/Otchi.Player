using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using LibVLCSharp.Shared;
using Timer = System.Timers.Timer;

namespace Otchi.Video
{

    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : UserControl
    {
        private readonly LibVLC _libVlc;
        private readonly MediaPlayer _mediaPlayer;
        private bool _isControlBarShowing = true;
        private DispatcherTimer _controlBarHideTimer;
        private static TimeSpan HideTime => new TimeSpan(0, 0, 0,0, 2000);
        private readonly Storyboard _storyboard = new Storyboard();
        private const int ControlPanelFadeTime = 200;
        private Duration ToHideDuration 
        {
            get
            {
                var curNormalizedPos = Canvas.GetBottom(ControlPanel) + ControlPanel.Height;
                var normalizedTargetPos = ControlPanel.Height;
                var percentageDone = curNormalizedPos / normalizedTargetPos;
                return new Duration(TimeSpan.FromMilliseconds(
                    ControlPanelFadeTime * percentageDone));
            }
        }
        private Duration ToShowDuration
        {
            get
            {
                var curNormalizedPos = Canvas.GetBottom(ControlPanel);
                var normalizedTargetPos = -ControlPanel.Height;
                var percentageDone = curNormalizedPos / normalizedTargetPos;
                return new Duration(TimeSpan.FromMilliseconds(
                    ControlPanelFadeTime * percentageDone));
            }
        }

        public VideoPlayer()
        {
            InitializeComponent();
            Core.Initialize();
            _libVlc = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVlc);
            VideoView.MediaPlayer = _mediaPlayer;
            //VideoView.Loaded += (sender, args) => Play(@"F:\repos\Otchi.Player\Otchi.App\bin\Debug\netcoreapp3.1\Downloads\[HorribleSubs] Ore wo Suki nano wa Omae dake ka yo - 02 [1080p].mkv");
            InitialiseDispatchTimer();
            RegisterName(ControlPanel.Name, ControlPanel);
        }

        private void InitialiseDispatchTimer()
        {
            _controlBarHideTimer = new DispatcherTimer();
            _controlBarHideTimer.Tick += (sender, args) => HideControlBar();
            _controlBarHideTimer.Interval = HideTime;
            _controlBarHideTimer.Start();
        }

        public void Play(string name)
        {
            using var media = new Media(_libVlc, name);
            _mediaPlayer.Play(media);
        }

        private void ResetControlBarTimer()
        {
            _controlBarHideTimer.Interval = HideTime;
            _controlBarHideTimer.Start();
        }

        public void ShowControlBar()
        {
            if (_isControlBarShowing) return;
            _isControlBarShowing = true;
            _storyboard.Stop();
            _storyboard.Remove();
            var anim = new DoubleAnimation
            {
                From = Canvas.GetBottom(ControlPanel),
                To = 0,
                Duration = ToShowDuration
            };
            var opaqueAnim = new DoubleAnimation
            {
                From = ControlPanel.Opacity,
                To = 1,
                Duration = ToShowDuration
            };
            _storyboard.AutoReverse = false;
            _storyboard.Children.Add(anim);
            _storyboard.Children.Add(opaqueAnim);
            Storyboard.SetTargetName(anim, ControlPanel.Name);
            Storyboard.SetTargetName(opaqueAnim, ControlPanel.Name);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Canvas.BottomProperty));
            Storyboard.SetTargetProperty(opaqueAnim, new PropertyPath(OpacityProperty));
            _storyboard.Begin(this);
        }

        public void HideControlBar()
        {
            _controlBarHideTimer.Stop();

            if (!_isControlBarShowing) return;
            _isControlBarShowing = false;
            _storyboard.Stop();
            _storyboard.Remove();
            var anim = new DoubleAnimation
            {
                From = Canvas.GetBottom(ControlPanel),
                To = -ControlPanel.Height,
                Duration = ToHideDuration
            };
            var opaqueAnim = new DoubleAnimation
            {
                From = ControlPanel.Opacity,
                To = 0,
                Duration = ToHideDuration
            };
            _storyboard.AutoReverse = false;
            _storyboard.Children.Add(anim);
            _storyboard.Children.Add(opaqueAnim);
            Storyboard.SetTargetName(anim, ControlPanel.Name);
            Storyboard.SetTargetName(opaqueAnim, ControlPanel.Name);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Canvas.BottomProperty));
            Storyboard.SetTargetProperty(opaqueAnim, new PropertyPath(OpacityProperty));
            _storyboard.Begin(this);
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

        private void Pause_Toggle(object sender, RoutedEventArgs e)
        {
            _mediaPlayer.SetPause(_mediaPlayer.IsPlaying);
        }


        private void VideoView_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_isControlBarShowing)
            {
                ResetControlBarTimer();
            }
            else
            {
                ShowControlBar();
            }
        }
    }
}
