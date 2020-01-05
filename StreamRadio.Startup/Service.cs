namespace StreamRadio.Startup
{
    public class Service
    {
        private readonly TelegramService _telegramService = new TelegramService();

        public void Start()
        {
            _telegramService.Start();
        }

        public void Stop()
        {
            _telegramService.Stop();
        }
    }
}