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
    public class DetailsModel : PageModel
    {
        private readonly LicenseTracker.Data.LicenseTrackerContext _context;

        public DetailsModel(LicenseTracker.Data.LicenseTrackerContext context)
        {
            _context = context;
        }

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
    }
}
