using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;

        // constructor injection
        public MovieController(IMovieService service)
        {
            _service = service;
        }

        // READ
        public IActionResult Index()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.AddMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            _service.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    


    //2nd prblm code below

    ////Application DbContext Injecting
    //private readonly ApplicationDbContext _context;

    ////constructor injecting
    //public MovieController(ApplicationDbContext context)
    //{ 
    //    _context = context;
    //}
    ////read operation
    //public IActionResult Index()
    //{
    //    var movies = _context.Movies.ToList();
    //    return View(movies);
    //}

    ////create get using
    //public IActionResult Create()
    //{
    //    return View();
    //}
    ////create post
    //[HttpPost]
    //public IActionResult Create(Movie movie)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Movies.Add(movie);
    //        _context.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    else
    //    {
    //        ViewBag.ErrorMessage = "Creation not Done";
    //        return View(movie);
    //    }
    //}

    ////edit get
    //public IActionResult Edit(int id)
    //{
    //    var movie = _context.Movies.Find(id);
    //    return View(movie);
    //}
    ////edit post
    //[HttpPost]
    //public IActionResult Edit(Movie movie)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Movies.Update(movie);
    //        _context.SaveChanges();
    //        return RedirectToAction("Index");
    //    } else
    //    {
    //        ViewBag.ErrorMessage = "Update is not Done";
    //        return View(movie);
    //    }
    //}
    ////delete
    //public IActionResult Delete(int id)
    //{
    //    if (ModelState.IsValid)
    //    {

    //        var movie = _context.Movies.Find(id);
    //        _context.Movies.Remove(movie);
    //        _context.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    else
    //    {
    //        ViewBag.ErrorsMessage = "invalid Id Found, Enter Valid Id";
    //        return View(id);
    //    }
    //}

}
}
