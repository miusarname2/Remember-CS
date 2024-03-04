using rememberCs.Models.DataModels;

namespace rememberCs.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<Student> GetStudentsIsnotCourse();

    }
}
