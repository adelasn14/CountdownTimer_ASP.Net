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
    public class DetailsModel : PageModel
    {
        private readonly TimerApp.WebForms.Data.TimerAppDbContext _context;

        public DetailsModel(TimerApp.WebForms.Data.TimerAppDbContext context)
        {
            _context = context;
        }

      public TimerItem TimerItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.CountdownTimer == null)
            {
                return NotFound();
            }

            var timeritem = await _context.CountdownTimer.FirstOrDefaultAsync(m => m.Id == id);
            if (timeritem == null)
            {
                return NotFound();
            }
            else 
            {
                TimerItem = timeritem;
            }
            return Page();
        }
    }
}
