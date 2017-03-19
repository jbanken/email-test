using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;

namespace Service.Config
{
    public static class InjectionConfig
    {
        public static void SetupInjections(IServiceCollection services)
        {
            services.AddSingleton<IEmailService, EmailService>();
        }
    }
}
