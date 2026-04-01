using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{

    //Controller create 
    public class ContactController : Controller
    {
        //injecting Serviece layer into controller
        private readonly IContactService _contactService;
        //readonly == value cannot change after assign
        //IContactService == type mean interface 
        //_contactService == it is variable (object reference)  used to acess servive methos inside controller)
      
        //constructor injectiing
        public ContactController(IContactService contactService)
        {
            //store injected object into variable
            _contactService = contactService;
        }

        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        public  IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");

            }
            return View(contactInfo);
        }
       
    }
}
