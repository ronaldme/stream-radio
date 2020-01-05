using System;
using log4net;
using System.Configuration;
using System.Threading.Tasks;
using StreamRadio.Services;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace StreamRadio.Startup
{
    public class TelegramService
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Radio _radio = new Radio();
        private readonly TelegramBotClient _bot = new TelegramBotClient(ConfigurationManager.AppSettings["telegramToken"]);

        public void Start()
        {
            _bot.OnMessage += BotOnMessageReceived;
            _bot.StartReceiving(Array.Empty<UpdateType>());

            Log.Info($"{nameof(TelegramService)} Started");
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null || message.Type != MessageType.Text) return;

            try
            {
                Log.Info($"Received: {e.Message.Text}");
            }
            catch (Exception exception)
            {
                Log.Error($"Could not handle message {message.Text}", exception);
            }
        }

        public void Stop() => Log.Info($"{nameof(TelegramService)} stopped");
    }
}