namespace LicenseTracker.Models
{
    public class User : BaseClass
    {
        public User()
        {
            Applications = new List<Application>();
        }

        public required string EmailAddress { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public List<Application>? Applications { get; set; }
    }
}
