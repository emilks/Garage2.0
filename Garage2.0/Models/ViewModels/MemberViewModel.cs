
using System.ComponentModel.DataAnnotations;
namespace Garage2._0.Models.ViewModels
{
    public class MemberViewModel
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
