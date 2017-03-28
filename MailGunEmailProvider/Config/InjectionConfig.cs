using Microsoft.Extensions.DependencyInjection;
using Email.MailGunEmailProvider.Interfaces;

namespace Email.MailGunEmailProvider.Config
{
    public static class InjectionConfig
    {
        public static void SetupInjections(IServiceCollection services)
        {
            services.AddSingleton<IMailGunService, MailGunService>();
        }
    }
}
