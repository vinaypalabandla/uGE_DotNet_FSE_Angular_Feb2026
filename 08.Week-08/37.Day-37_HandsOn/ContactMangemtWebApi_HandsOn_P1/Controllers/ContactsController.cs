using ContactManagement.API.DataAccess;
using ContactManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        //injecting repo
        private readonly IContactRepository _repo;
        //injecting Constructore
        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }
        //get by all
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        // get by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repo.GetById(id);

            if (contact == null)
                return NotFound("Contact not found");

            return Ok(contact);
        }

        //create using Post() method
        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            var newContact = _repo.AddContact(contact);

            return Ok(new{ newContact, message = "Contact added successfully"});
        }

        //update using put() method
        [HttpPut("{id}")]
        public IActionResult Update(int id, ContactInfo contact)
        {
            var updated = _repo.Update(id, contact);

            if (updated == null)
                return NotFound("Contact not found");

            return Ok(new { updated, message = "Contact added successfully" });
        }
        //delete using 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.DeleteContact(id);

            if (!result)
                return NotFound("Contact not found");

            return Ok(new { result, message = "Contact delete successfully" });
        }

    }
}
