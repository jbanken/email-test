using Email.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Email.Services.Config
{
    public static class InjectionConfig
    {
        public static void SetupInjections(IServiceCollection services)
        {
            DataProviders.Config.InjectionConfig.SetupInjections(services);
            services.AddSingleton<ISendService,SendService>();
        }
    }
}
