namespace LicenseTracker.Models
{
    public class Application : BaseClass
    {
        public Application()
        {
            ApplicationUsers = new List<ApplicationUser>();
        }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ContractTotal { get; set; }

        public int ContractDuration { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal CostPerUser { get; set; }

        public int MaxUsers { get; set; }

        public List<ApplicationUser>? ApplicationUsers { get; set; }


    }
}
