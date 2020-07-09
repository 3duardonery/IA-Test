using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RemoteControl.Domain.Models
{
    public class Device
    {
        public Device(string name, string oSVersion, 
            string ipAddress, string connectionId, 
            string antivirusName, bool hasAntivirus, double freeHardDisk, double hardDisk)
        {
            Name = name;
            OSVersion = oSVersion;
            IpAddress = ipAddress;
            ConnectionId = connectionId;
            AntivirusName = antivirusName;
            HasAntivirus = hasAntivirus;
            Id = new Guid();
            FreeHardDisk = freeHardDisk;
            HardDisk = hardDisk;
        }
        [Key]
        public Guid Id { get; set; }
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
