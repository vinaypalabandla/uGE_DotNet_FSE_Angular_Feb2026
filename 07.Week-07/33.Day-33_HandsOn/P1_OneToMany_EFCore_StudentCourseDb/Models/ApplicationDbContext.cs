using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace WebApplication4.Models
{
    public class ApplicationDbContext : DbContext
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
        // this 1st mrng pgrm example code
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dept> Depts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()

        //      .HasOne(e => e.Dept)
        //      .WithMany(d => d.Employees)
        //      .HasForeignKey(e => e.DeptId);
        //}

       // HandsOn First Code 1
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
              .HasOne(e => e.Dept)
              .WithMany(d => d.Employees)
              .HasForeignKey(e => e.DeptId);

            modelBuilder.Entity<Student>()
            .HasOne(s => s.Course)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.CourseId);
        }

    }
}
