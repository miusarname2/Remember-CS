using Microsoft.EntityFrameworkCore;
using rememberCs.Models.DataModels;

namespace rememberCs.DataAccess;

public class UniversityContext : DbContext
{
    public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
    {
        
    }
    // todo: Add DbSets (Tables of our DB)
    
    public DbSet<Users>? Users { get; set; }
    public DbSet<Course>? Courses { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Chapters> Chapters { get; set; }
}