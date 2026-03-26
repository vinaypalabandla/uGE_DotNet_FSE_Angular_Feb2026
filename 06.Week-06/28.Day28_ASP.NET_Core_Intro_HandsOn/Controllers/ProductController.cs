using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        List<Product> pdObj = new List<Product>()
        {
           new Product { Id = 1, Name ="Mobile", Price = 12000, Category = "Electronic" },
           new Product { Id = 2, Name = "Laptop", Price = 50000, Category = "Electronics" },
           new Product { Id = 3, Name = "buds", Price = 2000, Category = "Electronics" },
           new Product { Id = 4, Name = "Chair", Price = 3000, Category = "Furniture" },
           new Product { Id = 5, Name ="Mobile", Price = 12000, Category = "Electronic" },
           new Product { Id = 6, Name = "Laptop", Price = 50000, Category = "Electronics" },
           new Product { Id = 7, Name = "buds", Price = 2000, Category = "Electronics" },
           new Product { Id = 8, Name = "Chair", Price = 3000, Category = "Furniture" },
           new Product { Id = 9, Name = "buds", Price = 2000, Category = "Electronics" },
           new Product { Id = 10, Name = "Chair", Price = 3000, Category = "Furniture" }
         };
        public IActionResult Product()
        {
        
            return View(pdObj);
        }
        
        public IActionResult Details(int id)
        {
            var product = pdObj.Find(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
