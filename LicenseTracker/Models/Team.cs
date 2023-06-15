namespace LicenseTracker.Models
{
    public class Team : BaseClass
    {
        public Team()
        {
            Name = string.Empty;
            Users = new List<User>();
        }

        public List<User> Users { get; set; }
    }
}
