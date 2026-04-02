using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Students()
        {

            var stu = _context.Students.Include(s => s.Course).ToList();
            return View(stu);
        }
        public IActionResult Courses()
        {
            var courses = _context.Courses.Include(c => c.Students).ToList();
            return View(courses);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
