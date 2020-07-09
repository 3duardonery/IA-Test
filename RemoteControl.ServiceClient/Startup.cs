using RemoteControl.ServiceClient.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.ServiceClient
{
    public class Startup
    {
        private readonly ISignalService _signalService;

        public Startup(ISignalService signalRService)
        {
            _signalService = signalRService;
        }

        public void StartServices()
        {
            Task.Run(async () =>
            {
                await _signalService.StartConnection();

                await _signalService.SendMachineDetails();
            });
        }

        public void StopServices()
        {
            _signalService.CloseConnection();
        }
    }
}
