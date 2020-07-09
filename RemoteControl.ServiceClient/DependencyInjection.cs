using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using RemoteControl.ServiceClient.Domain.Interfaces;
using RemoteControl.ServiceClient.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControl.ServiceClient
{
    public static class DependencyInjection
    {
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<Startup>();

            services.AddSingleton<ISignalService, SignalService>();            

            services.AddSingleton<HubConnection>(
                new HubConnectionBuilder()
                    .WithUrl("http://localhost:5000/machine")                    
                    .Build());

            return services;
        }

        public static ServiceProvider BuildServiceProvider()
        {
            return ConfigureServices().BuildServiceProvider();
        }
    }
}
