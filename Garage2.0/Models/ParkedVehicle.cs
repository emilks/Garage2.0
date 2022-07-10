using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
#nullable disable
    public class ParkedVehicle
    {

        public int Id { get; set; }

        public VehicleType Type { get; set; }

        [Required]
        [StringLength(6)]
        public string RegNr { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int NrOfWheels { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime Date { get; internal set; }
    }
}
