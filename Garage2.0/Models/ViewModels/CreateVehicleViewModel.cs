using Garage2._0.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
#nullable disable
    public class CreateVehicleViewModel
    {
        [Required]
        [Display(Name = "Member")]
        public MemberViewModel Member { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Display(Name = "Number of Wheels")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int NrOfWheels { get; set; }
        public VehicleTypeViewModel VehicleType { get; set; }


       
      //  public int Size { get; set; }

    }
}
