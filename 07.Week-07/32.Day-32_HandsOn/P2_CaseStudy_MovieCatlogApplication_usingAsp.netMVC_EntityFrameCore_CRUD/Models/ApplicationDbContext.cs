using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Models

{
    // AppllicatinonDbContext is main clas to connect DB(database)
    //DbContext == inherts from EFC package and Handle the DatabaseOperations
    public class ApplicationDbContext : DbContext
    {
        //DB Configuration (connection Stirngs)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       // public DbSet<Product> Products { get; set; }
        //movieDBSET collections of table inside DB
        public DbSet<Movie> Movies { get; set; }

    }
}
