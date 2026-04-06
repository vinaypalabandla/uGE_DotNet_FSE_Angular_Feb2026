using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
        [Route("Contact")]
    public class ContactController : Controller
    {
     
     private readonly IContactService _service;

            public ContactController(IContactService service)
            {
                _service = service;
            }

            [HttpGet("ShowContacts")]
            public IActionResult ShowContacts()
            {
                var data = _service.GetAllContacts();
                return View(data);
            }

            [HttpGet("Details/{id}")]
            public IActionResult GetContactById(int id)
            {
                var data = _service.GetContactById(id);
                return View(data);
            }

            [HttpGet("Add")]
            public IActionResult AddContact()
            {
                ViewBag.Companies = _service.GetCompanies();     
                ViewBag.Departments = _service.GetDepartments();
                return View();
            }

            [HttpPost("Add")]
            public IActionResult AddContact(ContactInfo contact)
            {
                _service.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }

            [HttpGet("Edit/{id}")]
            public IActionResult EditContact(int id)
            {
                var data = _service.GetContactById(id);

            ViewBag.Companies = _service.GetCompanies();
            ViewBag.Departments = _service.GetDepartments();

            return View(data);
            }

            [HttpPost("Edit")]
            public IActionResult EditContact(ContactInfo contact)
            {
                _service.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }

            [HttpGet("Delete/{id}")]
            public IActionResult DeleteContact(int id)
            {
                _service.DeleteContact(id);
                return RedirectToAction("ShowContacts");

    }
}
}
