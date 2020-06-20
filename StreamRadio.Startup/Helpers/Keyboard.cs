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
                    new[] { GetKeyboardButton(RadioType.QMusicFouteUur)},
                    new[]
                    {
                        GetKeyboardButton(RadioType.QMusic),
                        GetKeyboardButton(RadioType.QMusicNonStop),
                        GetKeyboardButton(RadioType.Veronica),
                    },
                    new[]
                    {
                        GetKeyboardButton(RadioType.SkyRadio),
                        GetKeyboardButton(RadioType.BNR),
                        GetKeyboardButton(RadioType.Slam),
                    },
                    new[]
                    {
                        GetKeyboardButton(RadioType.Radio1),
                        GetKeyboardButton(RadioType.Radio2),
                        GetKeyboardButton(RadioType.ArrowClassicRock),
                    },
                    new[]
                    {
                        GetKeyboardButton(RadioType.Radio10NonStop),
                        GetKeyboardButton(RadioType.Radio1090Hits),
                        GetKeyboardButton(RadioType.Radio10),
                    },
                    new[]
                    {
                        new KeyboardButton("stop"),
                    }
                }
            };
        }

        private static KeyboardButton GetKeyboardButton(RadioType radioType)
            => new KeyboardButton(EnumHelper<RadioType>.GetEnumDescription(radioType.ToString()));
    }
}