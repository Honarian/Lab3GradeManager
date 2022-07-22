using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3GradeManager.Data;
using Lab3GradeManager.Model;

namespace Lab3GradeManager.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly Lab3GradeManager.Data.ApplicationDbContext _context;

        public IndexModel(Lab3GradeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Students> Students { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Students = await _context.Students.ToListAsync();
            }
        }
    }
}
