namespace VehiclesTracker.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string VehicleId { get; set; }
        public string RegNo { get; set; }

        public Customer Customer { get; set; }
    }
}
