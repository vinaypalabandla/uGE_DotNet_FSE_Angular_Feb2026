using ContactManagement.API.Models;
namespace ContactManagement.API.DataAccess
{
    public interface IContactRepository
    {
        public List<ContactInfo> GetAll();

        ContactInfo GetById(int id);
        ContactInfo AddContact(ContactInfo contact);
        ContactInfo Update(int id, ContactInfo contact);
        bool DeleteContact(int id);
    }
}
