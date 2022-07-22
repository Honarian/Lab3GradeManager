using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3GradeManager.Data;
using Lab3GradeManager.Model;

namespace Lab3GradeManager.Pages.Classes
{
    public class DeleteModel : PageModel
    {
        private readonly Lab3GradeManager.Data.ApplicationDbContext _context;

        public DeleteModel(Lab3GradeManager.Data.ApplicationDbContext context)
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

            var classrooms = await _context.Classrooms.FirstOrDefaultAsync(m => m.ClassId == id);

            if (classrooms == null)
            {
                return NotFound();
            }
            else 
            {
                Classrooms = classrooms;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Classrooms == null)
            {
                return NotFound();
            }
            var classrooms = await _context.Classrooms.FindAsync(id);

            if (classrooms != null)
            {
                Classrooms = classrooms;
                _context.Classrooms.Remove(Classrooms);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
