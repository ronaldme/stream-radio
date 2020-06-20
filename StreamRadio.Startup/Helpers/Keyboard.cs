using StreamRadio.Services;
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
                    new[] {new KeyboardButton(nameof(RadioType.QMusicFouteUur))},
                    new[]
                    {
                        new KeyboardButton(nameof(RadioType.QMusic)),
                        new KeyboardButton(nameof(RadioType.QMusicNonStop)),
                        new KeyboardButton(nameof(RadioType.Veronica)),
                    },
                    new[]
                    {
                        new KeyboardButton(nameof(RadioType.SkyRadio)),
                        new KeyboardButton(nameof(RadioType.BNR)),
                        new KeyboardButton(nameof(RadioType.Slam))
                    },
                    new[]
                    {
                        new KeyboardButton(nameof(RadioType.Radio1)),
                        new KeyboardButton(nameof(RadioType.Radio2)),
                        new KeyboardButton(nameof(RadioType.ArrowClassicRock))
                    },
                    new[]
                    {
                        new KeyboardButton(nameof(RadioType.Radio10NonStop)),
                        new KeyboardButton(nameof(RadioType.Radio1090Hits)),
                        new KeyboardButton(nameof(RadioType.Radio10))
                    },
                    new[]
                    {
                        new KeyboardButton("stop"),
                    }
                }
            };
        }
    }
}