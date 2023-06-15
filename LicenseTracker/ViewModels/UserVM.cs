namespace LicenseTracker.ViewModels
{
    public class UserVM : BaseClass
    {
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Team")]
        public int TeamId { get; set; }
        public string? TeamName { get; set; }

        [Display(Name = "# Applications")]
        public int? ApplicationCount { get; set; }

    }
}
