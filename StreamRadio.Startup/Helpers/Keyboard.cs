using Telegram.Bot.Types.ReplyMarkups;

namespace StreamRadio.Startup.Helpers
{
    public class Keyboard
    {
        public static ReplyKeyboardMarkup GetReplyKeyboard()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[] {new KeyboardButton("QMusicFouteUur")},
                    new[]
                    {
                        new KeyboardButton("QMusic"),
                        new KeyboardButton("Radio10"),
                        new KeyboardButton("Veronica"),
                    },
                    new[]
                    {
                        new KeyboardButton("SkyRadio"),
                        new KeyboardButton("BNR"),
                        new KeyboardButton("Slam")
                    },
                    new[]
                    {
                        new KeyboardButton("Radio1"),
                        new KeyboardButton("Radio2"),
                        new KeyboardButton("ArrowClassicRock")
                    }
                }
            };
        }
    }
}