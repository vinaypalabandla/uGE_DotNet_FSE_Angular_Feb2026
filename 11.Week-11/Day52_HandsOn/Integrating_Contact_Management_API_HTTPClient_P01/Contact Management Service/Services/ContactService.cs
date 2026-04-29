using Contact_Management_Service.Models;
using Contact_Management_Service.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Contact> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task Add(Contact contact)
        {
            await _repo.Add(contact);
        }

        public async Task Update(Contact contact)
        {
            await _repo.Update(contact);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
    }
}