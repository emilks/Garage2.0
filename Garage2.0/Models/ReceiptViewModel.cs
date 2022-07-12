
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class ReceiptViewModel
    {
        public VehicleType Type { get; set; }

        [Display(Name="Registration Number")]
        public string RegNr { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime LeaveTime { get; set; }

        public double TimeParked { get; set; }

        public double Price { get; set; }
    }
}
