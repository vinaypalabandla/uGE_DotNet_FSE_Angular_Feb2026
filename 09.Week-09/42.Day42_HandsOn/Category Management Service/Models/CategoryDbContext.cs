using Category_Management_Service.Models;
using Microsoft.EntityFrameworkCore;
namespace Category_Management_Service.Models
{
    public class CategoryDbContext :DbContext
    {

        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}