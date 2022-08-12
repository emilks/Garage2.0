using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models
{
    public class Member
    {
        
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [Remote(action: "FirstLastDiff", controller: "Members", ErrorMessage = "First and Last name must be different", AdditionalFields = nameof(FirstName))]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [Display(Name = "Person Nummer")]
        //[StringLength(12, ErrorMessage = "The personal registration number must be exactly length 12.", MinimumLength = 12)]
        //[Remote(action: "IsPerNrUsed", controller: "Members", ErrorMessage = "The personal registration number is already in use.", AdditionalFields = nameof(Id))]
        //[Remote(action: "PerNrFormat", controller: "Member", ErrorMessage = "", AdditionalFields = nameof(Id))]
        public string PerNr { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
