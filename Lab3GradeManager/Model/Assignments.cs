using System.ComponentModel.DataAnnotations;

namespace Lab3GradeManager.Model
{
    public class Assignments
    {
        [Key]
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public int AssignmentGrade { get; set; }
        public virtual Students Student { get; set; }
    }
}
