namespace Garage2._0.Models
{
    public class Member
    {
        //private Member()
        //{
        //    FirstName = null!;
        //    LastName = null!;
        //    PerNr = 0!;
        //}

        //public Member(string firstName, string lastName,  int perNr)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    PerNr = perNr;
        //}

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int PerNr { get; set; }

        IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
