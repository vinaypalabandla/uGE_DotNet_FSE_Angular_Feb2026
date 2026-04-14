using WebApplication8.ContactManagement.DAL.Models;
using WebApplication8.Models;

namespace WebApplication8.ContactManagement.DAL.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllAsync(); 
        Task<ContactInfo?> GetByIdAsync(int id);        
        Task AddAsync(ContactInfo contact);
        Task UpdateAsync(ContactInfo contact);
        Task DeleteAsync(int id);
    }
}