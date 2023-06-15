namespace LicenseTracker.ViewModels
{
    public class BusinessUnitViewModel
    {
        public BusinessUnitViewModel()
        {
            Name = string.Empty;
            AppData = new List<BUAppViewModel>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }

        public List<BUAppViewModel> AppData { get; set; }


    }

    public class BUAppViewModel
    {
        public int AppId { get; set; }
        public int CountUsers { get; set; }
        public decimal BUCost { get; set; }

    }
}