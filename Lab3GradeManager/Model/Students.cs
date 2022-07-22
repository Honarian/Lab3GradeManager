using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3GradeManager.Model
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        public virtual Classrooms Classrooms { get; set; }


    }
}
