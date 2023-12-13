using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimerApp.WebForms.Data;
using TimerApp.WebForms.Models;

namespace TimerApp.WebForms.Pages.Timer
{
    public class EditModel : PageModel
    {
        private readonly TimerApp.WebForms.Data.TimerAppDbContext _context;

        public EditModel(TimerApp.WebForms.Data.TimerAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TimerItem TimerItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.CountdownTimer == null)
            {
                return NotFound();
            }

            var timeritem =  await _context.CountdownTimer.FirstOrDefaultAsync(m => m.Id == id);
            if (timeritem == null)
            {
                return NotFound();
            }
            TimerItem = timeritem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TimerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimerItemExists(TimerItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TimerItemExists(Guid id)
        {
          return (_context.CountdownTimer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
