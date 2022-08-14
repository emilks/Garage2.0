using System.ComponentModel;

namespace Garage2._0.Models.ViewModels
{
    public class MembersViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name Of Owner")]
        public string MemberFullName { get; set; }

        [DisplayName("ID")]
        public string MemberPerNr { get; set; }

        [DisplayName("Count Of Vehicle")]

        public int VehiclesCount { get; set; }

    }
}
