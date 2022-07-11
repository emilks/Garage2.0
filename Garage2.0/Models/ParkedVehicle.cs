﻿using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
#nullable disable
    public class ParkedVehicle
    {

        public int Id { get; set; }
        [Display(Name = "Type of Vehicle")]
        public VehicleType Type { get; set; }

        [Required(ErrorMessage = "6 characters is required")]
        [StringLength(6), MinLength(6)]
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
        [Display(Name = "Number of Wheels")]
        public int NrOfWheels { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
