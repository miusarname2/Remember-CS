using System.ComponentModel.DataAnnotations;

namespace rememberCs.Models.DataModels
{

    public enum Lvl
    {
        Easy,
        Medium,
        Hard,
        Pro
    }

    public class Course : BaseEntity
    {
        [Required,StringLength(100)]
        public string name {  get; set; } = string.Empty;

        [Required,StringLength(100)]
        public string shortDescription { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        [Required]
        public Lvl Level { get; set; } = Lvl.Easy;

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public Chapters Index { get; set; } = new Chapters();
    }
}
