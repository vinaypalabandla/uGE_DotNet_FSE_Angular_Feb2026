using Microsoft.Extensions.Caching.Memory;
using WebApplication9.Models;
using WebApplication9.Repositories;

namespace WebApplication9.Services
{
    public class ContactService
    {

        private readonly ContactRepository _repo;
        private readonly IMemoryCache _cache;

        public ContactService(ContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            string key = "contacts";

            if (!_cache.TryGetValue(key, out List<Contact> data))
            {
                data = _repo.GetAll(); // DB call

                _cache.Set(key, data, TimeSpan.FromSeconds(60));
            }
            else
            {
                Console.WriteLine("Data from CACHE");
            }

            return data;
        }

        public Contact GetContactById(int id)
        {
            string key = "contact_" + id;

            if (!_cache.TryGetValue(key, out Contact contact))
            {
                contact = _repo.GetById(id);

                _cache.Set(key, contact, TimeSpan.FromSeconds(60));
            }

            return contact;
        }
    }
}
