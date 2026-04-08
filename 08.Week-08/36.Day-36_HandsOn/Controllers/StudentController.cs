using Microsoft.AspNetCore.Mvc;
using WebApplication6.Repositories;
namespace WebApplication6.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }
        public IActionResult StudentsWithCourse()
        {
            var data = _repo.GetStudentsWithCourse();
            return View(data);
        }

        // Courses + Students
        public IActionResult CoursesWithStudents()
        {
            var data = _repo.GetCoursesWithStudents();
            return View(data);
        }
    }
}
