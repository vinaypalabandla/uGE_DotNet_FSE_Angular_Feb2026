using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        // Static List with sample data
        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo { ContactId = 1, FirstName = "Vinay", LastName = "Kumar", CompanyName = "CTS", EmailId = "vinay@gmail.com", MobileNo = 9999999999, Designation = "Developer" },
            new ContactInfo { ContactId = 2, FirstName = "Rahul", LastName = "Kumar", CompanyName = "TCS", EmailId = "rahul@gmail.com", MobileNo = 8888888888, Designation = "Tester" }
        };

        // Show all contacts
        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        // Get contact by ID
        public IActionResult GetContactById(int id)
        {
            ContactInfo contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        // GET Add Contact
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        // POSTAdd Contact
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid data. Some validations failed.";
                return View();
            }
        }
    }
}