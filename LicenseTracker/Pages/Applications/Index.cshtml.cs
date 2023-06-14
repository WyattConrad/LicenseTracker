using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LicenseTracker.Data;
using LicenseTracker.Models;

namespace LicenseTracker.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private readonly LicenseTracker.Data.LicenseTrackerContext _context;

        public IndexModel(LicenseTracker.Data.LicenseTrackerContext context)
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
