using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ProductModelController : Controller
    {
        private static List<dynamic> products = new List<dynamic>();

        [HttpGet]
        [Route("product/index")]
        public IActionResult Index1()
        {
            ViewBag.Products = products;
            return View();
        }
        [HttpPost]
        [Route("product/index")]
        public IActionResult Index1(string name, double price, int quantity)
        {
            // add product to list
            products.Add(new
            {
                Name = name,
                Price = price,
                Quantity = quantity
            });

            ViewBag.Products = products;
            return View();
        }
        [HttpGet]
        [Route("product/add")]
        public IActionResult Add()
        {
            return View();
        }
    }
    }
