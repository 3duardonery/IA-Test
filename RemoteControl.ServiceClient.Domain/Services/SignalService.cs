using Microsoft.AspNetCore.SignalR.Client;
using RemoteControl.ServiceClient.Domain.Interfaces;
using RemoteControl.ServiceClient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteControl.ServiceClient.Domain.Services
{
    public class SignalService : ISignalService
    {
        private readonly HubConnection _hubConnection;

        public SignalService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }

        public async Task CloseConnection()
        {
            await _hubConnection.StopAsync();
        }

        public async Task SendMachineDetails()
        {
            try
            {
                var machineDetails = new DeviceDetails
                {
                    Name = Device.Name,
                    FreeHardDisk = Device.Disks.FreeDisk,
                    HardDisk = Device.Disks.TotalDisk,
                    OSVersion = Device.OSVersion,
                    IpAddress = Device.IpAddress,
                    HasAntivirus = Device.Antivirus.HasAntivirus,
                    AntivirusName = Device.Antivirus.AntivirusName,
                    ConnectionId = _hubConnection.ConnectionId
                };

                var machineDetailsStr = JsonSerializer.Serialize(machineDetails);

                await _hubConnection.InvokeAsync("RegisterDeviceInformation", machineDetailsStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task StartConnection()
        {
            try
            {
                await _hubConnection.StartAsync();

                BuildHandlers();
            }
            catch (Exception)
            {

                throw;
            }
        }



        private void BuildHandlers()
        {
            _hubConnection.On<string>("HandShake", (machine) =>
            {
                Console.WriteLine(machine);
            });


        }

    }
}
