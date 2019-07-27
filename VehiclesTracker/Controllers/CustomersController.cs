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
    public class CustomersController : ControllerBase
    {
        CustomerManager _customerManager;

        public CustomersController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await Task.Run(() => new JsonResult(_customerManager.GetCustomers()));
        }

        // GET api/customers/getwithvehicles
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetWithVehicles(int id)
        {
            return await Task.Run(() => new JsonResult(_customerManager.GetCustomersWithVehicles()));
        }
    }
}