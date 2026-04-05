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

        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Employee>()
            //  .HasOne(e => e.Dept)
            //  .WithMany(d => d.Employees)
            //  .HasForeignKey(e => e.DeptId);

            //modelBuilder.Entity<Student>()
            //.HasOne(s => s.Course)
            //.WithMany(c => c.Students)
            //.HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<ContactInfo>()
            .HasOne(c => c.Company)
            .WithMany(c => c.Contacts)
            .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<ContactInfo>()
                .HasKey(c => c.ContactId); 
            modelBuilder.Entity<ContactInfo>()

                .HasOne(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId);
        }


    }
}
