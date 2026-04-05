using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Repository;

using Microsoft.AspNetCore.Mvc;
namespace WebApplication4.Controllers
{
[Route("contact")]
    public class ContactController : Controller
    {

  
        private readonly IContactRepository _repo;
        private readonly ApplicationDbContext _context;

        public ContactController(IContactRepository repo, ApplicationDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult ShowContacts()
        {
            return View(_repo.GetAllContacts());
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            return View(_repo.GetContactById(id));
        }

        [HttpGet("add")]
        public IActionResult AddContact()
        {
            ViewBag.Companies = _context.Companies.ToList();
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("edit/{id}")]
        public IActionResult EditContact(int id)
        {
            ViewBag.Companies = _context.Companies.ToList();
            ViewBag.Departments = _context.Departments.ToList();
            return View(_repo.GetContactById(id));
        }

        [HttpPost("edit")]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        
    }
}
}
