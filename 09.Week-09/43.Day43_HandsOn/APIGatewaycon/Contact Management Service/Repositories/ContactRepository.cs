using Contact_Management_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Contact_Management_Service.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

}
