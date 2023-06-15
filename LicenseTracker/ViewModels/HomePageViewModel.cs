namespace LicenseTracker.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            Applications = new List<ApplicationViewModel>();
            BusinessUnits = new List<BusinessUnitViewModel>();
        }
        public List<ApplicationViewModel> Applications { get; set; }

        public List<BusinessUnitViewModel> BusinessUnits { get; set; }

    }
}
