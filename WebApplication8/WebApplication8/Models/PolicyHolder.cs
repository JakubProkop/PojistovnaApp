namespace WebApplication8.Models
{
    public class PolicyHolder
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int TelephoneNumber { get; set; }
        public string Street { get; set; } = "";

        public string City { get; set; } = "";
        public int PostCode { get; set; }

        public ICollection<Assurance> Assurances { get; set; }

        public PolicyHolder() 
        {
            Assurances = new List<Assurance>();
        }
    }
}
