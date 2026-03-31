using Microsoft.AspNetCore.Mvc; 

namespace WebApplication2.Controllers
{
    [Route("student")] // attribute route
   public class StudentController : Controller
    {
        // GET 
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST
        [HttpPost("submit")]
        public IActionResult Submit(string studentName, int age, string course)
        {
            // Redirect to Display action with data
            return RedirectToAction("Display", new
            {
                name = studentName,
                age = age,
                course = course
            });
        }

        // GET
        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
           
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }

    }
}
