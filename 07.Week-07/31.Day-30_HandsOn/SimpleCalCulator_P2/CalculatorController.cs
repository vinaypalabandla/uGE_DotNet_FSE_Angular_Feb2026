using Microsoft.AspNetCore.Mvc; 
 
namespace WebApplication2.Controllers 
{
    [Route("calc")] // atribute route
   public class CalculatorController : Controller
   {
        // GET 
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        // POST 
        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            ViewData["Result"] = result;

            return View();
        }
        // GET 
        [HttpGet("sub")]
        public IActionResult Sub()
        {
            return View();
        }

        // POST 
        [HttpPost("sub")]
        public IActionResult Sub(int num1, int num2)
        {
            int result = num1 - num2;

            ViewData["Result"] = result;

            return View();
        }

        // GET 
        [HttpGet("mul")]
        public IActionResult Mul()
        {
            return View();
        }

        // POST 
        [HttpPost("mul")]
        public IActionResult Mul(int num1, int num2)
        {
            int result = num1*num2;

            ViewData["Result"] = result;

            return View();
        }

        // GET 
        [HttpGet("div")]
        public IActionResult Div()
        {
            return View();
        }

        // POST 
        [HttpPost("div")]
        public IActionResult Div(int num1, int num2)
        {
            int result = num1/num2;

            ViewData["Result"] = result;

            return View();
        }
    }
}
