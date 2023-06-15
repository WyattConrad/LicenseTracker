namespace LicenseTracker.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly LicenseTrackerContext _context;

        public DetailsModel(LicenseTrackerContext context)
        {
            _context = context;
        }

      public UserVM User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Team)
                .Include(u => u.Applications)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = new UserVM
                {
                    Id = user.Id,
                    Name = user.Name,
                    EmailAddress = user.EmailAddress,
                    TeamId = user.TeamId,
                    TeamName = user.Team.Name,
                    ApplicationCount = user.Applications?.Count
                };
            }
            return Page();
        }
    }
}
