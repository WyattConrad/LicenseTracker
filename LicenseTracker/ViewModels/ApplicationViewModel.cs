using System.ComponentModel.DataAnnotations;

namespace LicenseTracker.ViewModels
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
            Name = string.Empty;
            ContractTotal = 0;
            ContractDuration = 0;
            CostPerUser = 0;
            MaxUsers = 0;
            CountUsers = 0;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ContractTotal { get; set; }

        public int ContractDuration { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal CostPerUser { get; set; }

        public int MaxUsers { get; set; }

        public int CountUsers { get; set; }

        public int AvailableUsers => MaxUsers - CountUsers;

    }
}
