using RemoteControl.ServiceClient.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RemoteControl.ServiceClient.Domain
{
    public static class Device
    {
        public static string Name => Environment.MachineName;

        public static string OSVersion => Environment.OSVersion.VersionString;

        public static string IpAddress => GetIpAddress();

        public static Antivirus Antivirus => GetAntivirus();

        public static Disk Disks => GetDisk();

        private static string GetIpAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork)?.ToString();
        }

        private static Disk GetDisk()
        {
            try
            {
                DriveInfo cDrive = new DriveInfo("C");

                return new Disk
                {
                    FreeDisk = Math.Abs((cDrive.TotalFreeSpace / 1024) / 1024),
                    TotalDisk = Math.Abs((cDrive.TotalSize / 1024) / 1024)
                };                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static Antivirus GetAntivirus()
        {
            string antivirus = String.Empty;

            ManagementObjectSearcher wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
            ManagementObjectCollection data = wmiData.Get();

            var machineAntivirus = new Antivirus
            {
                HasAntivirus = data.Count > 0
            };

            foreach (ManagementObject virusChecker in data)
            {
                machineAntivirus.AntivirusName += String.Join(" ", virusChecker["displayName"].ToString());
            }

            return machineAntivirus;
        }
    }
}
