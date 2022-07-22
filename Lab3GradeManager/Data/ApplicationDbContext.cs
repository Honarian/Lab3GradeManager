using Lab3GradeManager.Model;
using Microsoft.EntityFrameworkCore;


namespace Lab3GradeManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Classrooms> Classrooms { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
    }
}
