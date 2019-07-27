using System;
using System.Collections.Generic;
using System.Text;
using VehiclesTracker.Data.Core;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Business.Managers
{
    public class VehicleManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _unitOfWork.Vehicles.GetAll();
        }

        public List<Vehicle> GetVehiclesPerCustomer(int customerId)
        {
            return _unitOfWork.Vehicles.GetVehiclesPerCustomer(customerId);
        }
    }
}
