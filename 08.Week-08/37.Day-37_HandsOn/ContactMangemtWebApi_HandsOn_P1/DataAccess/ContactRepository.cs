using ContactManagement.API.Models;
namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        //static List
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo {ContactId =1, FirstName ="Vinay",LastName="Kumar",EmailId="vinay@Gmail.com",MobileNo =9876543212,Designation="Developer",CompanyId =101,DepartmentId = 101},
            new ContactInfo {ContactId =2, FirstName ="Vinay",LastName="chowdary",EmailId="vini@Gmail.com",MobileNo =9876543213,Designation="Tester",CompanyId =102,DepartmentId = 102},
            new ContactInfo {ContactId =3, FirstName ="Vini",LastName="",EmailId="vinay112@Gmail.com",MobileNo =9876543218,Designation="Developer",CompanyId =103,DepartmentId = 103}
        };
        //get All
        public List<ContactInfo> GetAll()
        {
            return contacts;
        }
        //get by Id
        public ContactInfo GetById(int id)
        {
            return contacts.FirstOrDefault(f => f.ContactId == id);
        }
        //Add Contact
        public ContactInfo AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return contact;
        }
        //update
        public ContactInfo Update(int id, ContactInfo updated)
        {
           
            var contact = contacts.FirstOrDefault(u => u.ContactId == id);

            if (contact == null)
            {
                return null;
            }
            contact.FirstName = updated.FirstName;
            contact.LastName = updated.LastName;
            contact.EmailId = updated.EmailId;
            contact.MobileNo = updated.MobileNo;
            contact.Designation = updated.Designation;
            contact.CompanyId = updated.CompanyId;
            contact.DepartmentId = updated.DepartmentId;

            return contact;
        }

        //delete
        public bool DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }
    } 
}
