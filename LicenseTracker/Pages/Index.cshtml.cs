using LicenseTracker.Data;
using LicenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LicenseTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LicenseTrackerContext _context;

        public IndexModel(ILogger<IndexModel> logger, LicenseTrackerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public HomePageViewModel ViewModel { get; set; } = default!;

        public void OnGet()
        {
            var applications = _context.Application.Include(a => a.Users).OrderBy(a => a.Name).Select(a => new ApplicationViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ContractDuration = a.ContractDuration,
                ContractTotal = a.ContractTotal,
                CostPerUser = a.CostPerUser,
                MaxUsers = a.MaxUsers,
                CountUsers = a.Users != null ? a.Users.Count() : 0
            }).ToList();
            ViewModel = new HomePageViewModel
            {
                Applications = applications
            };
        }
    }
}