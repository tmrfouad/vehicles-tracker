using System;
using System.Collections.Generic;
using System.Text;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Data.Core
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        List<Vehicle> GetVehiclesPerCustomer(int customerId);
    }
}
