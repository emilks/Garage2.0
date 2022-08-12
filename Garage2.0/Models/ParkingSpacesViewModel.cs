namespace Garage2._0.Models
{
    public class ParkingSpacesViewModel
    {
        public int Id { get; set; }

        public int ParkingNr { get; set; }

        public bool Occupied { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string? RegNr { get; set; }

        public string Type { get; set; }

        public int VehicleId { get; set; }

    }
}
