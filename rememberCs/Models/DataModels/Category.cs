using System.ComponentModel.DataAnnotations;

namespace rememberCs.Models.DataModels
{
    public class Category:BaseEntity
    {
        [Required]
        public string name {  get; set; } = string.Empty;


        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
