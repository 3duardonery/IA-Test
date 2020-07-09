using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControl.ServiceClient.Domain.Models
{
    public class DeviceDetails
    {
        public string Name { get; set; }
        public string OSVersion { get; set; }
        public string IpAddress { get; set; }
        public bool HasAntivirus { get; set; }
        public string AntivirusName { get; set; }
        public Disk Disk { get; set; }
        public double HardDisk { get; set; }
        public double FreeHardDisk { get; set; }
        public string ConnectionId { get; set; }

    }
}
