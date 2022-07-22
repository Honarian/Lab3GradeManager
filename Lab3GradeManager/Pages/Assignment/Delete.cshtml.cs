using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3GradeManager.Data;
using Lab3GradeManager.Model;

namespace Lab3GradeManager.Pages.Assignment
{
    public class DeleteModel : PageModel
    {
        private readonly Lab3GradeManager.Data.ApplicationDbContext _context;

        public DeleteModel(Lab3GradeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Assignments Assignments { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var assignments = await _context.Assignments.FirstOrDefaultAsync(m => m.AssignmentId == id);

            if (assignments == null)
            {
                return NotFound();
            }
            else 
            {
                Assignments = assignments;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }
            var assignments = await _context.Assignments.FindAsync(id);

            if (assignments != null)
            {
                Assignments = assignments;
                _context.Assignments.Remove(Assignments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
