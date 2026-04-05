using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication4.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailId { get; set; }
            public long MobileNo { get; set; }
            public string Designation { get; set; }

            public int CompanyId { get; set; }
            public int DepartmentId { get; set; }

            // Navigation Properties
            public Company Company { get; set; }
            public Department Department { get; set; }
        
    }
}
