using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemoteControl.Domain.Interfaces.Services;

namespace RemoteControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public MachinesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public IActionResult GetMachines()
        {
            var devices = _deviceService.GetAll();
            return Ok(devices);
        }
    }
}
