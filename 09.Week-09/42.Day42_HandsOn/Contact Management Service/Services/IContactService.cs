using Contact_Management_Service.Models;

namespace Contact_Management_Service.Services
{
    public interface IContactService
    {
       
            Task<IEnumerable<Contact>> GetAll();
            Task<Contact> GetById(int id);
            Task Add(Contact contact);
            Task Update(Contact contact);
            Task Delete(int id);
        
    }
}
