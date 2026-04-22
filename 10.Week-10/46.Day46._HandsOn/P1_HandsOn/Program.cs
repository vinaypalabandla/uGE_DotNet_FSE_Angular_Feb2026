using ContactMangemntCodeAnlysis.Services;

namespace ContactMangemntCodeAnlysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new ContactService();

            service.AddContact(new Models.Contact
            {
                Name = "Vinay",
                Email = "vinay@gmail.com",
                Phone = "6699523322"
            });
            Console.WriteLine("All Contacts:");
            foreach(var contact in service .GetAllContacts())
            {
                Console.WriteLine($"{{contact.Id}} - {{contact.Name}} - {{contact.Email}}\"");
            }
        }
    }
}
