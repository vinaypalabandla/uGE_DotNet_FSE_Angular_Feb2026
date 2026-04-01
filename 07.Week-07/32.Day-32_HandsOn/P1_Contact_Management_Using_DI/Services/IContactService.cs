using System.Collections.Generic;
using WebApplication3.Models;
namespace WebApplication3.Services
{

    //Creating Interface for  IContactService class
    public interface IContactService
    {
        //Methods are implemented  Here GetAllContacts, GetContactById, AddContact
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);

        void AddContact(ContactInfo contact);
    }
}
