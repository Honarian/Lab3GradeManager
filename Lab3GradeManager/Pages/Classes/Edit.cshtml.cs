using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3GradeManager.Data;
using Lab3GradeManager.Model;

namespace Lab3GradeManager.Pages.Classes
{
    public class EditModel : PageModel
    {
        private readonly Lab3GradeManager.Data.ApplicationDbContext _context;

        public EditModel(Lab3GradeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Classrooms Classrooms { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Classrooms == null)
            {
                return NotFound();
            }

            var classrooms =  await _context.Classrooms.FirstOrDefaultAsync(m => m.ClassId == id);
            if (classrooms == null)
            {
                return NotFound();
            }
            Classrooms = classrooms;
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

            _context.Attach(Classrooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomsExists(Classrooms.ClassId))
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

        private bool ClassroomsExists(int id)
        {
          return (_context.Classrooms?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
