using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimerApp.WebForms.Data;
using TimerApp.WebForms.Models;

namespace TimerApp.WebForms.Pages.Timer
{
    public class IndexModel : PageModel
    {
        private readonly TimerApp.WebForms.Data.TimerAppDbContext _context;

        public IndexModel(TimerApp.WebForms.Data.TimerAppDbContext context)
        {
            _context = context;
        }

        public IList<TimerItem> TimerItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CountdownTimer != null)
            {
                TimerItem = await _context.CountdownTimer.ToListAsync();
            }
        }
    }
}
