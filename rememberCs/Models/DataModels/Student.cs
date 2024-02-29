using System.ComponentModel.DataAnnotations;

namespace rememberCs.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        public string lastName { get; set; } = string.Empty ;

        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course> courses { get; set; } = new List<Course>();
    }
}
