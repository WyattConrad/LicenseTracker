
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LicenseTracker.Pages.Users
{
    public class UserPageModel : PageModel
    {
        public SelectList TeamSL { get; set; }
        public SelectList ApplicationSL { get; set; }

        public void PopulateTeamsDropDownList(LicenseTrackerContext _context,
            object selectedTeam = null)
        {
            var teamQuery = from t in _context.Team
                                   orderby t.Name // Sort by name.
                                   select t;

            TeamSL = new SelectList(teamQuery.AsNoTracking(),
                nameof(Team.Id),
                nameof(Team.Name),
                selectedTeam);
        }

        public void PopulateApplicationsDropDownList(LicenseTrackerContext _context, object selectedApp = null)
        {
              var appQuery = from a in _context.Application
                           orderby a.Name // Sort by name.
                           select a;

            ApplicationSL = new SelectList(appQuery.AsNoTracking(),
                               nameof(Application.Id),
                                nameof(Application.Name),
                                selectedApp);
        }
    }
}
