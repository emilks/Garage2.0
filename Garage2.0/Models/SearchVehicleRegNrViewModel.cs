using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Garage2._0.Models;

public class SearchVehicleRegNrViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Registration Number")]
    [StringLength(6, ErrorMessage = "The registration number must be exactly length 6.", MinimumLength = 6)]
    [Remote(action: "NoVehicle", controller: "Vehicles", ErrorMessage = "Cannot find the Registration number.")]
    public string? RegNr { get; set; }

}