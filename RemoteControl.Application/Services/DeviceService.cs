using RemoteControl.Domain.Inputs;
using RemoteControl.Domain.Interfaces.Services;
using RemoteControl.Domain.Models;
using RemoteControl.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteControl.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private RemoteControlDbContext _context; 
        public DeviceService(RemoteControlDbContext context)
        {
            _context = context;
        }
        public void Save(InDevice device)
        {
            Device dispositivo = new Device(
                name: device.Name,
                oSVersion: device.OSVersion,
                ipAddress: device.IpAddress,
                connectionId: device.ConnectionId,
                antivirusName: device.AntivirusName,
                hasAntivirus: device.HasAntivirus,
                freeHardDisk: device.FreeHardDisk,
                hardDisk: device.HardDisk
            );

            _context.Device.Add(dispositivo);

            _context.SaveChanges();
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Device.ToList<Device>();
        }

        public Device GetByConnectionId(string connectionId)
        {
            var selectedDevice = _context.Device
                .Where(x => x.ConnectionId.Equals(connectionId))
                .FirstOrDefault();

            return selectedDevice;    
        
        }

        public void DeleteDevice(Guid id)
        {
            var deleteDevice = _context.Device.Where(x => x.Id == id).FirstOrDefault();
            _context.Device.Remove(deleteDevice);
            _context.SaveChanges();
        }
    }
}
