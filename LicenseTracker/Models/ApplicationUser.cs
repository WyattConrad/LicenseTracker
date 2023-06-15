namespace LicenseTracker.Models
{
    public class ApplicationUser
    {
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
