using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace StreamRadio.Services
{
    public class Radio
    {
        private CancellationTokenSource _source;

        private readonly Dictionary<RadioType, string> _radioStreams = new Dictionary<RadioType, string>
        {
            {RadioType.QMusicFouteUur, "https://icecast-qmusicnl-cdp.triple-it.nl/Qmusic_nl_fouteuur_96.mp3"},
            {RadioType.QMusic, "https://icecast-qmusicnl-cdp.triple-it.nl/Qmusic_nl_live_96.mp3"},
            {RadioType.Radio10, "http://19993.live.streamtheworld.com/RADIO10.mp3"},
            {RadioType.Veronica, "https://20873.live.streamtheworld.com/VERONICA.mp3"},
            {RadioType.SkyRadio, "https://19993.live.streamtheworld.com/SKYRADIO.mp3"},
            {RadioType.BNR, "http://icecast-bnr.cdp.triple-it.nl/bnr_mp3_128_03"},
            {RadioType.Slam, "https://stream.slam.nl/slam_mp3"},
            {RadioType.Radio1, "http://icecast.omroep.nl/radio1-bb-mp3"},
            {RadioType.Radio2, "http://icecast.omroep.nl/radio2-bb-mp3"},
            {RadioType.ArrowClassicRock, "https://stream.gal.io/arrow"},
        };

        public void PlayStream(RadioType radioType)
        {
            CurrentRadio = radioType;
            var url = _radioStreams[radioType];

            _source?.Cancel();

            _source = new CancellationTokenSource();
            var task = PlayMusic(url, _source.Token);
            task.Start();
        }

        public RadioType CurrentRadio { get; private set; }

        private Task PlayMusic(string url, CancellationToken sourceToken)
        {
            return new Task(() =>
            {
                using var mf = new MediaFoundationReader(url);
                using var wo = new WaveOutEvent();

                wo.Init(mf);
                wo.Play();

                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    Task.Delay(1000, sourceToken);

                    if (sourceToken.IsCancellationRequested)
                        throw new TaskCanceledException();
                }
            }, sourceToken);
        }

        public void StopStreaming()
        {
            CurrentRadio = RadioType.None;
            _source?.Cancel();
        }
    }
}
