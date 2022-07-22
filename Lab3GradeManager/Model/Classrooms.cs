using System.ComponentModel.DataAnnotations;

namespace Lab3GradeManager.Model
{
    public class Classrooms
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
