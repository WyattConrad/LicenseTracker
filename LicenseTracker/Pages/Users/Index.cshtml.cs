using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LicenseTracker.Data;
using LicenseTracker.Models;

namespace LicenseTracker.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly LicenseTracker.Data.LicenseTrackerContext _context;

        public IndexModel(LicenseTracker.Data.LicenseTrackerContext context)
        {
            _context = context;
        }

        public IList<UserVM> Users { get;set; } = default!;

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
                    ApplicationCount = u.Applications != null ? u.Applications.Count() : 0
                }).ToListAsync();
            }
        }
    }
}
