using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: feedback form
        [HttpGet]
        [Route("feedback/form")]
        public IActionResult Form()
        {
            return View();
        }

        // POST: handle form submission
        [HttpPost]
        [Route("feedback/form")]
        public IActionResult Form(string name, string comments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback!";
            }

            return View();
        }
    }
}
