using Microsoft.AspNetCore.Mvc;
using LicenseTracker.Data;
using LicenseTracker.Models;
using LicenseTracker.ViewModels;

namespace LicenseTracker.Pages.Users
{
    public class CreateModel : UserPageModel
    {
        private readonly LicenseTrackerContext _context;

        public CreateModel(LicenseTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateTeamsDropDownList(_context);
            PopulateApplicationsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public UserVM NewUser { get; set; }

        [BindProperty]
        public int[] Applications { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                PopulateTeamsDropDownList(_context, NewUser.TeamId);
                PopulateApplicationsDropDownList(_context, Applications);
                return Page();
            }

            var entry = _context.Add(new User{ EmailAddress = "abc@123.com", Name = "First Last", TeamId = 1});
            entry.CurrentValues.SetValues(NewUser);
            await _context.SaveChangesAsync();

            foreach (var i in Applications)
            {
                var thisApp = _context.Application.Find(i);
                if (thisApp is not null)
                {
                    var appUser = new ApplicationUser
                    {
                        ApplicationId = thisApp.Id,
                        UserId = entry.Entity.Id
                    };
                    _context.Add(appUser);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
