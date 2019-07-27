using System;
using System.Collections.Generic;
using System.Text;
using VehiclesTracker.Data.Core;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Business.Managers
{
    public class CustomerManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _unitOfWork.Customers.GetAll();
        }

        public List<Customer> GetCustomersWithVehicles()
        {
            return _unitOfWork.Customers.GetCustomersWithVehicles();
        }
    }
}
