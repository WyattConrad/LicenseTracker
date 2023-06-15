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
            var businessUnits = _context.Team
                .OrderBy(t => t.Name)
                .Select(t => new BusinessUnitViewModel
                {
                    TeamId = t.Id,
                    Name = t.Name
                }).ToList();

            var applications = _context.Application
                .Include(a => a.ApplicationUsers)
                .OrderBy(a => a.Name)
                .Select(a => new ApplicationViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    ContractDuration = a.ContractDuration,
                    ContractTotal = a.ContractTotal,
                    CostPerUser = a.CostPerUser,
                    MaxUsers = a.MaxUsers,
                    CountUsers = a.ApplicationUsers != null ? a.ApplicationUsers.Count() : 0
                }).ToList();

            foreach (var bu in businessUnits)
            {
                var users = _context.User.Where(u => u.TeamId == bu.TeamId).Select(u => u.Id).ToList();
                var appUsers = _context.ApplicationUser.Where(au => users.Contains(au.UserId)).Select(au => au.ApplicationId).ToList();
                foreach(var app in applications)
                {
                    if (appUsers.Contains(app.Id))
                    {
                        var appData = new BUAppViewModel
                        {
                            AppId = app.Id,
                            CountUsers = appUsers.Where(au => au == app.Id).Count(),
                            BUCost = app.CostPerUser * appUsers.Where(au => au == app.Id).Count(),
                        };
                        bu.AppData.Add(appData);
                    }
                }
            }

            ViewModel = new HomePageViewModel
            {
                Applications = applications,
                BusinessUnits = businessUnits
            };
        }
    }
}