using VehiclesTracker.Data.Core;
using VehiclesTracker.Data.Repositories;

namespace VehiclesTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehiclesTrackerDBContext _context;
        public ICustomerRepository Customers { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }

        public UnitOfWork(VehiclesTrackerDBContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Vehicles = new VehicleRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
