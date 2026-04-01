using System.Collections.Generic;
using WebApplication3.Models;
namespace WebApplication3.Services
{
    //ContactService  = SeriveceLayer (It Handles the busines logig and data handling)
    // create or Implement ContactService Class(Concrete class) and Inherted from Interface class (IcontactService)
    public class ContactService : IContactService
    {

        //Stores all contacts act ad temaparory database 
        private static List<ContactInfo> contacts = new List<ContactInfo>();

        //returns full list ShowContactPage
        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        //Searches by GetContactById usinf FirstOrDefault() or Find() methods
        public ContactInfo GetContactById(int id)
        {
           // return contacts.FirstOrDefault(c => c.ContactId == id);

            foreach(var c in contacts)
            {
                if(c.ContactId == id)
                {
                    return c;
                }
                
  
            }
                   return null;
        }
        //Add New Contcat to list
        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }
    }
}
