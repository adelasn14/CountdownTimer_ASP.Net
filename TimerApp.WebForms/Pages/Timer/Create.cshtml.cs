using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimerApp.WebForms.Data;
using TimerApp.WebForms.Models;

namespace TimerApp.WebForms.Pages.Timer
{
    public class CreateModel : PageModel
    {
        private readonly TimerApp.WebForms.Data.TimerAppDbContext _context;

        public CreateModel(TimerApp.WebForms.Data.TimerAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TimerItem TimerItem { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.CountdownTimer == null || TimerItem == null)
            {
                return Page();
            }

            _context.CountdownTimer.Add(TimerItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
