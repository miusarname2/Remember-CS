using System.ComponentModel.DataAnnotations;

namespace rememberCs.Models.DataModels
{
    public class Chapters : BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string List = string.Empty;

    }
}
