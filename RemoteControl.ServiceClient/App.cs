using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControl.ServiceClient
{
    public class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = DependencyInjection.BuildServiceProvider();
        }

        public void Start()
        {
            _serviceProvider.GetService<Startup>().StartServices();
        }

        public void Stop()
        {
            _serviceProvider.GetService<Startup>().StopServices();
        }
    }
}
