namespace LicenseTracker.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly LicenseTrackerContext _context;

        public DeleteModel(LicenseTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);

            if (user != null)
            {
                var appUser = await _context.ApplicationUser.Where(au => au.UserId == user.Id).ToListAsync();
                User = user;
                _context.ApplicationUser.RemoveRange(appUser);
                _context.User.Remove(User);
                
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
