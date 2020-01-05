using System.Threading.Tasks;
using Topshelf;

namespace StreamRadio.Startup
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            HostFactory.Run(hostConfig =>
            {
                hostConfig.StartAutomaticallyDelayed();

                hostConfig.EnableServiceRecovery(serviceRecovery =>
                {
                    serviceRecovery.RestartService(5);
                });

                hostConfig.Service<Service>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() => new Service());
                    serviceConfig.WhenStarted(s => s.Start());
                    serviceConfig.WhenStopped(s => s.Stop());
                });
            });
        }
    }
}
