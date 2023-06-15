namespace LicenseTracker.Pages.Applications
{
    public class DeleteModel : PageModel
    {
        private readonly LicenseTrackerContext _context;

        public DeleteModel(LicenseTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Application Application { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application.FirstOrDefaultAsync(m => m.Id == id);

            if (application == null)
            {
                return NotFound();
            }
            else 
            {
                Application = application;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }
            var application = await _context.Application.FindAsync(id);

            if (application != null)
            {
                Application = application;
                _context.Application.Remove(Application);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
