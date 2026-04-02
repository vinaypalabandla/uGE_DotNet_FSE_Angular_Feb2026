using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        //injecting the Application Db context into  the Controller
        private readonly ApplicationDbContext _context;

        //Constructor Injected
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Emps()
        {
            // var emps = _context.Employees.ToList();    // Navigation properties becomes null
            var emps = _context.Employees.Include(e => e.Dept).ToList();
            return View(emps);
        }
        public IActionResult Depts()
        {
            var depts = _context.Depts.Include(d => d.Employees).ToList();
            return View(depts);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
