using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class EmpController : Controller
    {
       
        public IActionResult Employee()
        {
            List<Employee> empObj = new List<Employee>()
            {
                new Employee { Empno = 1, Ename = "Vinay", Job = "Developer", Salary = 50000, Deptno = 10 },
                new Employee { Empno = 2, Ename = "Rahul", Job = "Tester", Salary = 40000, Deptno = 20 },
                new Employee { Empno = 3, Ename = "Anu", Job = "Manager", Salary = 70000, Deptno = 30 }
            };

            return View(empObj);
        }
    }
}
