using System.Collections.Generic;

namespace VehiclesTracker.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Vehicle> Vehicles { get; set; }

    }
}
