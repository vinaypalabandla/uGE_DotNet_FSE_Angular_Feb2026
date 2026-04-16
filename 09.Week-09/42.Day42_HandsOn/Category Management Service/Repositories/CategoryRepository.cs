using Category_Management_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Category_Management_Service.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;
        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetById(int id) => await _context.Categories.FindAsync(id);

        public async Task Add(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}

