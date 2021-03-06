﻿using Email.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Email.Services.Config
{
    public static class InjectionConfig
    {
        public static void SetupInjections(IServiceCollection services)
        {
            Email.DataProviders.Config.InjectionConfig.SetupInjections(services);
            Email.MailGunEmailProvider.Config.InjectionConfig.SetupInjections(services);
            services.AddSingleton<ISendService,SendService>();
        }
    }
}
