using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehiclesTracker.Data.Core;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public VehiclesTrackerDBContext Context
        {
            get
            {
                return _context as VehiclesTrackerDBContext;
            }
        }

        public CustomerRepository(DbContext context) : base(context) { }

        public List<Customer> GetCustomersWithVehicles()
        {
            return Context.Customers
            .Include(c => c.Vehicles)
            .ToList();
        }
    }
}
