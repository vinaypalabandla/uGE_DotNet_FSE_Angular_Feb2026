using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Price = 50000, Category = "Electronics" },
            new Product { ProductId = 2, ProductName = "Mobile", Price = 20000, Category = "Electronics" },
            new Product { ProductId = 3, ProductName = "AC", Price = 5000, Category = "Electronics" },
            new Product { ProductId = 4, ProductName = "Cooler", Price = 2000, Category = "Electronics" },
            new Product { ProductId = 5, ProductName = "Chair", Price = 500, Category = "Furnture" },
            new Product { ProductId = 6, ProductName = "Buds", Price = 200, Category = "Electronics" }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        // Details
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }


        // Create Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create Post
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)   // VALIDATION CHECK
            {
                products.Add(obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        // Edit GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        // Edit Post
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
           
               var existing = products.FirstOrDefault(p => p.ProductId == obj.ProductId);

                existing.ProductName = obj.ProductName;
                existing.Price = obj.Price;
                existing.Category = obj.Category;

            return RedirectToAction("Index"); 
        }

        //Delete GEt
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            products.Remove(product);

            return RedirectToAction("Index");
        }

    }
}
