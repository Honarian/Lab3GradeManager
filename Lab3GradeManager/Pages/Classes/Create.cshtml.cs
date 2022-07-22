using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab3GradeManager.Data;
using Lab3GradeManager.Model;

namespace Lab3GradeManager.Pages.Classes
{
    public class CreateModel : PageModel
    {
        private readonly Lab3GradeManager.Data.ApplicationDbContext _context;

        public CreateModel(Lab3GradeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Classrooms Classrooms { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Classrooms == null || Classrooms == null)
            {
                return Page();
            }

            _context.Classrooms.Add(Classrooms);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
