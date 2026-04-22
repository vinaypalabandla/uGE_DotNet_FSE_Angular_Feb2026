using ContactMangemntCodeAnlysis.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ContactMangemntCodeAnlysis.Services
{
    public class ContactService : IContactService
    {
        //In Memory list to store contacts
        private readonly List<Contact> _contacts = new();

        public void AddContact(Contact contact)
        {
            ValidateContact(contact);
            //Assigning the ID here
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            ValidateContact(updatedContact);

            var contact = FindContactById(id);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contact.Name = updatedContact.Name;
            contact.Email = updatedContact.Email;
            contact.Phone = updatedContact.Phone;
        }

        public void DeleteContact(int id)
        {
            var contact = FindContactById(id);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            _contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }


        private Contact? FindContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        private void ValidateContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required");

            if (string.IsNullOrWhiteSpace(contact.Email))
                throw new ArgumentException("Email is required");

            if (string.IsNullOrWhiteSpace(contact.Phone))
                throw new ArgumentException("Phone is required");
        }
    }
    }