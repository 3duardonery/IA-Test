using System;
using Topshelf;

namespace RemoteControl.ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<App>(service => {
                    service.ConstructUsing(s => new App());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("RemoteControl");
                x.SetDisplayName("Remote Control");
                x.SetDescription("Remote Control with SignalR");
            });
        }
    }
}
