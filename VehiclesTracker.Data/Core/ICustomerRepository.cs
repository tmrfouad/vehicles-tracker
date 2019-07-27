using System;
using System.Collections.Generic;
using System.Text;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Data.Core
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> GetCustomersWithVehicles();
    }
}
