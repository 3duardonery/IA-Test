using RemoteControl.Domain.Inputs;
using RemoteControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControl.Domain.Interfaces.Services
{
    public interface IDeviceService
    {
        void Save(InDevice device);
        IEnumerable<Device> GetAll();
        Device GetByConnectionId(string connectionId);
        void DeleteDevice(Guid id);
    }
}
