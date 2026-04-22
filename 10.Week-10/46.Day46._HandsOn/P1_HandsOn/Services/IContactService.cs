using ContactMangemntCodeAnlysis.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMangemntCodeAnlysis.Services
{
    public class IContactService
    {
        //Add new Contcat
        void AddContact(Contact contact);
        //Update existing contact
        void UpdateContact(int id, Contact updatedContact);
        //Delete contact by  id
        void DeleteContact(int id);
        //Get all Contacts
        List<Contact> GetAllContacts();
    }
}
