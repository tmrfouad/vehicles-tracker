using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehiclesTracker.Data.Core;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehiclesTrackerDBContext Context
        {
            get
            {
                return _context as VehiclesTrackerDBContext;
            }
        }

        public VehicleRepository(DbContext context) : base(context) { }

        public List<Vehicle> GetVehiclesPerCustomer(int customerId)
        {
            return Context.Vehicles
                .Where(v => v.CustomerId == customerId)
                .ToList();
        }
    }
}
