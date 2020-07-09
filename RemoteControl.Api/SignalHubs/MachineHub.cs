using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RemoteControl.Domain.Inputs;
using RemoteControl.Domain.Interfaces.Services;
using RemoteControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteControl.Api.SignalHubs
{
    public class MachineHub : Hub 
    {
        List<InDevice> devices = new List<InDevice>();
        private string ConnectionId => Context.ConnectionId;
        private readonly IDeviceService _deviceService;

        public MachineHub(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var machine = _deviceService.GetByConnectionId(connectionId: ConnectionId);

            _deviceService.DeleteDevice(machine.Id);

            UpdateMachineList();

            return base.OnDisconnectedAsync(exception);
        }

        public void RegisterDeviceInformation(string informationJson)
        {
            var device = JsonConvert.DeserializeObject<Device>(informationJson);

            var inputDevice = new InDevice 
            (
                name: device.Name,
                oSVersion: device.OSVersion,
                ipAddress: device.IpAddress,
                connectionId: device.ConnectionId,
                antivirusName: device.AntivirusName,
                hasAntivirus: device.HasAntivirus,
                freeHardDisk: device.FreeHardDisk,
                hardDisk: device.HardDisk
            );

            _deviceService.Save(inputDevice);
            UpdateMachineList();
        }

        public Task UpdateMachineList()
        {
            return Clients.All.SendAsync("ForceUpdate", true);
        }
    }
}
