using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehiclesTracker.Business.Managers;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        VehicleManager _vehicleManager;

        public VehiclesController(VehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        // GET api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            return await Task.Run(() => new JsonResult(_vehicleManager.GetVehicles()));
        }

        // GET api/vehicles/getbycustomer
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetByCustomer(int customerId)
        {
            return await Task.Run(() => new JsonResult(_vehicleManager.GetVehiclesPerCustomer(customerId)));
        }
    }
}