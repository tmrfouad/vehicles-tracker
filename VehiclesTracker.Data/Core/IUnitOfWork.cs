using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesTracker.Data.Core
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IVehicleRepository Vehicles { get; }

        int Complete();
    }
}
