using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public interface IContactRepository
    {

        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);
    
}
}
