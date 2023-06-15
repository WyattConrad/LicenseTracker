namespace LicenseTracker.Models
{
    public class User : BaseClass
    {
        public User()
        {
            Applications = new List<ApplicationUser>();
        }

        public required string EmailAddress { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public List<ApplicationUser>? Applications { get; set; }
    }
}
