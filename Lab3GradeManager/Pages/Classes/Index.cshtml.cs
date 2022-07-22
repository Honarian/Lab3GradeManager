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
    public class IndexModel : PageModel
    {
        private readonly Lab3GradeManager.Data.ApplicationDbContext _context;

        public IndexModel(Lab3GradeManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Classrooms> Classrooms { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Classrooms != null)
            {
                Classrooms = await _context.Classrooms.ToListAsync();
            }
        }
    }
}
