using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public class ContactRepository
    {

            private static List<Contact> contacts = new List<Contact>
    {
        new Contact { ContactId = 1, Name = "Vinay", Email = "vinay@test.com" },
        new Contact { ContactId = 2, Name = "Rahul", Email = "rahul@test.com" }
    };

            public List<Contact> GetAll()
            {
                Console.WriteLine("Data from DB");
                return contacts;
            }

            public Contact GetById(int id)
            {
                Console.WriteLine("Data from DB");
                return contacts.FirstOrDefault(x => x.ContactId == id);
            }
        }
    
}
