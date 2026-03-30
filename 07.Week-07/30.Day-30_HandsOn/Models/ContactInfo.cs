using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ContactInfo
    {
          [Required(ErrorMessage = "Contact Id is required")]
            public int ContactId { get; set; }

            [Required(ErrorMessage = "First Name is required")]
            [StringLength(10, MinimumLength = 3, ErrorMessage = "First Name must be 3 to 10 characters")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is required")]
            [StringLength(10, MinimumLength = 3, ErrorMessage = "Last Name must be 3 to 10 characters")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Company Name is required")]
            [StringLength(10, MinimumLength = 3, ErrorMessage = "Company Name must be 3 to 10 characters")]
            public string CompanyName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid Email format")]
            public string EmailId { get; set; }

            [Required(ErrorMessage = "Mobile Number is required")]
            [Range(1000000000, 9999999999, ErrorMessage = "Enter valid 10-digit number")]
            public long MobileNo { get; set; }

            [Required(ErrorMessage = "Designation is required")]
            [StringLength(10, MinimumLength = 2, ErrorMessage = "Designation must be 2 to 10 characters")]
            public string Designation { get; set; }
        }
    }
