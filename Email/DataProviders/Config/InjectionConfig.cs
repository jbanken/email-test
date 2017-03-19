using Email.DataProviders.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Email.DataProviders.Config
{
    public static class InjectionConfig
    {
        public static void SetupInjections(IServiceCollection services)
        {
            services.AddSingleton<IEmailDataProvider, EmailDataProvider>();
        }
    }
}
