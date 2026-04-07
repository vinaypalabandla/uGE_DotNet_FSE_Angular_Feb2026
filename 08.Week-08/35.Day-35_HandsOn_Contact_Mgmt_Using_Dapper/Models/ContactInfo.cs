using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Models
{
    public class ContactInfo
    {
        [Required]
        public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public long MobileNo { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int DepartmentId { get; set; }



    }
}
