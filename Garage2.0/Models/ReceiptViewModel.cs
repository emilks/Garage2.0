namespace Garage2._0.Models
{
#nullable disable
    public class ReceiptViewModel
    {
        public VehicleType Type { get; set; }

        public string RegNr { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime LeaveTime { get; set; }

        public DateTime TimeParked { get; set; }

        public int Price { get; set; }
    }
}
