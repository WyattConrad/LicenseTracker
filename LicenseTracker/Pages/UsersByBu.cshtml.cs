namespace LicenseTracker.Pages
{
    public class UsersByBuModel : PageModel
    {
        private readonly LicenseTrackerContext _context;

        public UsersByBuModel(LicenseTrackerContext context)
        {
            _context = context;
        }
        public IList<UserVM> Users { get; set; } = default!;
        public SelectList TeamSL { get; set; } = default!;

        [BindProperty]
        public string selectedValue { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                Users = await _context.User
                .Include(u => u.Team)
                .Include(u => u.Applications)
                .Select(u => new UserVM
                {
                    Id = u.Id,
                    Name = u.Name,
                    TeamId = u.TeamId,
                    TeamName = u.Team.Name,
                    EmailAddress = u.EmailAddress,
                    ApplicationCount = u.Applications != null ? u.Applications.Count() : 0,
                    ApplicationIds = u.Applications != null ? u.Applications.Select(a => a.ApplicationId).ToArray() : new int[0]
                }).OrderBy(u => u.TeamName).ThenBy(u => u.Name).ToListAsync();

                //Add the total application cost per user
                var applicationCostPerUser = await _context.Application
                    .Select(au => new
                    {
                        au.Id,
                        au.CostPerUser
                    }).ToListAsync();
                foreach (var u in Users)
                {
                    u.TotalApplicationCost = 0;
                    if (u.ApplicationIds != null && u.ApplicationIds.Length > 0)
                    {
                        foreach (var a in u.ApplicationIds)
                        {
                            u.TotalApplicationCost += applicationCostPerUser.Where(au => au.Id == a).Select(au => au.CostPerUser).FirstOrDefault();
                        }
                    }
                }

            }
            TeamSL = new SelectList(_context.Team.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,
            }).OrderBy(t => t.Text).ToList(), "Value", "Text");
        }


        public async Task OnPostAsync()
        {

            if (_context.User != null)
            {
                Users = await _context.User
                    .Include(u => u.Team)
                    .Include(u => u.Applications)
                    .Select(u => new UserVM
                    {
                        Id = u.Id,
                        Name = u.Name,
                        TeamId = u.TeamId,
                        TeamName = u.Team.Name,
                        EmailAddress = u.EmailAddress,
                        ApplicationCount = u.Applications != null ? u.Applications.Count() : 0,
                        ApplicationIds = u.Applications != null ? u.Applications.Select(a => a.ApplicationId).ToArray() : new int[0]
                    }).OrderBy(u => u.TeamName).ThenBy(u => u.Name).ToListAsync();

                //If the user selected a team, filter the list to only show users on that team
                var intSelectedValue = Convert.ToInt32(selectedValue);
                if (intSelectedValue != 0)
                {
                    Users = Users.Where(u => u.TeamId == intSelectedValue).ToList();
                }

                //Add the total application cost per user
                var applicationCostPerUser = await _context.Application
                    .Select(au => new
                    {
                        au.Id,
                        au.CostPerUser
                    }).ToListAsync();
                foreach(var u in Users)
                {
                    u.TotalApplicationCost = 0;
                    if (u.ApplicationIds != null && u.ApplicationIds.Length > 0)
                    {
                        foreach (var a in u.ApplicationIds)
                        {
                            u.TotalApplicationCost += applicationCostPerUser.Where(au => au.Id == a).Select(au => au.CostPerUser).FirstOrDefault();
                        }
                    }
                }
                
            }
            TeamSL = new SelectList(_context.Team.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,
            }).OrderBy(t => t.Text).ToList(), "Value", "Text");

        }
    }
}
