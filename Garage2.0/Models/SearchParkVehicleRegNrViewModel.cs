using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Garage2._0.Models;

public class SearchParkVehicleRegNrViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Registration Number")]
    [StringLength(6, ErrorMessage = "The registration number must be exactly length 6.", MinimumLength = 6)]
    [Remote(action: "NoVehicle", controller: "Vehicles", ErrorMessage = "Cannot find the Registration number.")]
    //[Remote(action: "GarageFull", controller: "Vehicles", ErrorMessage = "The Garage is currently full.")]
    //[Remote(action: "InGarage", controller: "Vehicles", ErrorMessage = "This vehicle is already parked in the garage.")]
    public string? RegNr { get; set; }

}