using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using NAudio.Wave;

namespace StreamRadio.WPF
{
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _source;

        private Task _task;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void QMusicFouteUurClick(object sender, RoutedEventArgs e)
        {
            string url = "https://icecast-qmusicnl-cdp.triple-it.nl/Qmusic_nl_fouteuur_96.mp3";
            HandleStreamClick(url);
        }

        private void QMusicClick(object sender, RoutedEventArgs e)
        {
            string url = "https://icecast-qmusicnl-cdp.triple-it.nl/Qmusic_nl_live_96.mp3";
            HandleStreamClick(url);
        }

        private void Radio10Click(object sender, RoutedEventArgs e)
        {
            string url = "http://icecast-qmusicnl-cdp.triple-it.nl/Qmusic_nl_live_96.mp3";
            HandleStreamClick(url);
        }

        private void VeronicaClick(object sender, RoutedEventArgs e)
        {
            string url = "https://20873.live.streamtheworld.com/VERONICA.mp3";
            HandleStreamClick(url);
        }

        private void SkyRadioClick(object sender, RoutedEventArgs e)
        {
            string url = "https://19993.live.streamtheworld.com/SKYRADIO.mp3";
            HandleStreamClick(url);
        }

        private void BNRClick(object sender, RoutedEventArgs e)
        {
            string url = "http://icecast-bnr.cdp.triple-it.nl/bnr_mp3_96_04.m3u";
            HandleStreamClick(url);
        }

        private void SlamClick(object sender, RoutedEventArgs e)
        {
            string url = "https://stream.slam.nl/slam_mp3";
            HandleStreamClick(url);
        }

        private void Radio1Click(object sender, RoutedEventArgs e)
        {
            string url = "http://icecast.omroep.nl/radio1-bb-mp3";
            HandleStreamClick(url);
        }

        private void Radio2Click(object sender, RoutedEventArgs e)
        {
            string url = "http://icecast.omroep.nl/radio2-bb-mp3";
            HandleStreamClick(url);
        }

        private void ArrowClassicRockClick(object sender, RoutedEventArgs e)
        {
            string url = "https://stream.gal.io/arrow";
            HandleStreamClick(url);
        }

        private void HandleStreamClick(string url)
        {
            _source?.Cancel();

            var source = new CancellationTokenSource();
            _task = CreateNewTask(url, source.Token);
            _task.Start();
        }

        private Task CreateNewTask(string url, CancellationToken sourceToken)
        {
            return new Task(() =>
            {
                using (var mf = new MediaFoundationReader(url))
                using (var wo = new WaveOutEvent())
                {
                    wo.Init(mf);
                    wo.Play();

                    while (wo.PlaybackState == PlaybackState.Playing)
                    {
                        Task.Delay(1000, sourceToken);

                        if (sourceToken.IsCancellationRequested)
                            throw new TaskCanceledException();
                    }
                }
            }, sourceToken);
        }
    }
}