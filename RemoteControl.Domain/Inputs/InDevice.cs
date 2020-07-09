using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControl.Domain.Inputs
{
    public class InDevice
    {
        public InDevice(string name, string oSVersion, string ipAddress, 
            string connectionId, string antivirusName, 
            bool hasAntivirus, double freeHardDisk, double hardDisk)
        {
            Name = name;
            OSVersion = oSVersion;
            IpAddress = ipAddress;
            ConnectionId = connectionId;
            AntivirusName = antivirusName;
            HasAntivirus = hasAntivirus;
            FreeHardDisk = freeHardDisk;
            HardDisk = hardDisk;
        }

        public string Name { get; private set; }
        public string OSVersion { get; private set; }
        public string IpAddress { get; private set; }
        public string ConnectionId { get; private set; }
        public string AntivirusName { get; private set; }
        public bool HasAntivirus { get; private set; }
        public double FreeHardDisk { get; set; }
        public double HardDisk { get; set; }

    }
}
