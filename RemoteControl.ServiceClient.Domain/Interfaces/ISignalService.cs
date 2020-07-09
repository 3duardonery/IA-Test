using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.ServiceClient.Domain.Interfaces
{
    public interface ISignalService
    {
        Task StartConnection();
        Task CloseConnection();
        Task SendMachineDetails();
    }
}
