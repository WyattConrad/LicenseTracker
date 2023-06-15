namespace LicenseTracker.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private readonly LicenseTrackerContext _context;

        public IndexModel(LicenseTrackerContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Application != null)
            {
                Application = await _context.Application.OrderBy(a => a.Name).ToListAsync();
            }
        }
    }
}
