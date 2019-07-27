using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VehiclesTracker.DataGen;
using VehiclesTracker.SignalRHubs;

namespace VehiclesTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private IHubContext<VehiclesHub> _hub;

        public TrackerController(IHubContext<VehiclesHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transfervehiclesdata", DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}