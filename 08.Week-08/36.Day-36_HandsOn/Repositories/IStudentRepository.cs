using WebApplication6.Models;

namespace WebApplication6.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Course> GetCoursesWithStudents();
    }
}
