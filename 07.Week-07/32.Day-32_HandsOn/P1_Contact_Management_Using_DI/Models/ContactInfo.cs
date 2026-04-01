using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.Models
{
    //model class creation
    public class ContactInfo
    {
        [Required(ErrorMessage ="Required Id")]
        public int ContactId { get; set; }

        //validation  provide  based on using stringlength() method 
        [Required(ErrorMessage = "Please Enter FirstName")]
        [StringLength(10,MinimumLength =3, ErrorMessage = "First Name should be between 3 and 10")]
        public string FirstName { get; set; }

        //validation provide using the Stirng Length() method
        [Required(ErrorMessage = "Please Enter LastName")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Last Name should be between 3 and 10")]
        public string LastName { get; set; }
        //validation provide based  on the Stirng
        [Required(ErrorMessage ="Please enter Company name")]
        [StringLength(10,MinimumLength =3,ErrorMessage = "Company Name In B/W 3 to 10 characters only")]
        public string CompanyName { get; set; }

        //validation using Email Address
        [EmailAddress(ErrorMessage="Please Enter The Vaild Email")]
        [Required(ErrorMessage ="Email is Required")]
        public string EmailId { get; set; }

        //validation provide using regular expression
        [Required(ErrorMessage="Required mobile number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage="Please provide the Mobile number")]
        public long MobileNo{ get; set; }
        [Required(ErrorMessage="Enter theDisgnation")]
        public string Designation { get; set; }

    }
}
