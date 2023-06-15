namespace LicenseTracker.Pages.Applications
{
    public class CreateModel : PageModel
    {
        private readonly LicenseTrackerContext _context;

        public CreateModel(LicenseTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Application Application { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Application == null || Application == null)
            {
                return Page();
            }

            _context.Application.Add(Application);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
