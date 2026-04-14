using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication8.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public long MobileNo { get; set; }
        //Foregin keys
        public string? Designation { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        //Naviagtion Properties
        [JsonIgnore]
        public Company? Company { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }


    }
}
