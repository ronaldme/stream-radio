using System.ComponentModel;

namespace StreamRadio.Services
{
    public enum RadioType
    {
        None,

        [Description("Q-music foute uur")]
        QMusicFouteUur,

        [Description("Q-music")]
        QMusic,

        [Description("Radio 10")]
        Radio10,

        [Description("Veronica")]
        Veronica,

        [Description("SkyRadio")]
        SkyRadio,

        [Description("BNR")]
        BNR,

        [Description("SLAM!")]
        Slam,

        [Description("Radio 1")]
        Radio1,

        [Description("Radio 2")]
        Radio2,

        [Description("Arrow Classic Rock")]
        ArrowClassicRock,
    }
}