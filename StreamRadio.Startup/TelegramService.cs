using System;
using log4net;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using StreamRadio.DAL;
using StreamRadio.Services;
using StreamRadio.Startup.Helpers;
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
        private readonly string _authenticationKey = ConfigurationManager.AppSettings["authenticationKey"];
        private readonly TelegramBotClient _bot = new TelegramBotClient(ConfigurationManager.AppSettings["telegramToken"]);
        private readonly UserRepository _userRepository = new UserRepository();

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

                await HandleMessageImpl(message);
            }
            catch (Exception exception)
            {
                Log.Error($"Could not handle message {message.Text}", exception);
            }
        }

        private async Task HandleMessageImpl(Message message)
        {
            var text = message.Text;

            var user = _userRepository.GetUser(message.Chat.Id);

            var commands = text.Split(' ');
            var action = commands.First();

            switch (action)
            {
                case "/start":
                    if (user == null) await _bot.SendTextMessageAsync(message.Chat.Id, "Welcome to StreamRadio.\n\n" +
                                                                                       "Please authenticate with /authenticate YOUR_KEY");
                    else await _bot.SendTextMessageAsync(message.Chat.Id, "Welcome back to StreamRadio.", replyMarkup: Keyboard.GetReplyKeyboard());
                    break;
                case "/authenticate" when user == null:
                    if (commands.Length != 2)
                    {
                        await _bot.SendTextMessageAsync(message.Chat.Id, "Wrong number of arguments.");
                        return;
                    }

                    if (commands[1] == _authenticationKey)
                    {
                        _userRepository.CreateUser(message.Chat.Username, message.Chat.Id);
                        await _bot.SendTextMessageAsync(message.Chat.Id, "You are now authenticated, enjoy streaming.", replyMarkup: Keyboard.GetReplyKeyboard());
                    }
                    else
                        await _bot.SendTextMessageAsync(message.Chat.Id, $"Wrong API key: {commands[1]}.");
                    break;
                case "/help":
                    await _bot.SendTextMessageAsync(message.Chat.Id, "/start - start streaming \n" +
                                            (user == null ? "\n/authenticate - authenticate and start streaming" : null));
                    break;
            }

            if (user != null)
            {
                RadioType radioType = (RadioType)Enum.Parse(typeof(RadioType), text);
                _radio.PlayStream(radioType);
            }
        }

        public void Stop() => Log.Info($"{nameof(TelegramService)} stopped");
    }
}