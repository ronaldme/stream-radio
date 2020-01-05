using System;
using System.Windows;
using StreamRadio.Services;

namespace StreamRadio.WPF
{
    public partial class MainWindow : Window
    {
        private readonly Radio _radio = new Radio();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void QMusicFouteUurClick(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.QMusicFouteUur);

        private void QMusicClick(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.QMusic);

        private void Radio10Click(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.Radio10);

        private void VeronicaClick(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.Veronica);

        private void SkyRadioClick(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.SkyRadio);

        private void BNRClick(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.BNR);

        private void SlamClick(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.Slam);

        private void Radio1Click(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.Radio1);

        private void Radio2Click(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.Radio2);

        private void ArrowClassicRockClick(object sender, RoutedEventArgs e) => _radio.PlayStream(RadioType.ArrowClassicRock);
    }
}