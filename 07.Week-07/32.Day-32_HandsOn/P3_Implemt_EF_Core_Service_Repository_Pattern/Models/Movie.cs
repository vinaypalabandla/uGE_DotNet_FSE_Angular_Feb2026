using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace WebApplication3.Models
{
    public class Movie
    {
        [Required(ErrorMessage ="Id Is required")]
        public int Id { get; set; }

        [Required(ErrorMessage="Title is required")]
        [StringLength(10,ErrorMessage ="Maximun10 character")]
        public string Title { get; set; }
        //validation done by using StirngLength() method and Required()
        [Required]
        [StringLength(100,ErrorMessage ="Maximum 10 character")]
        public string Genre { get; set; }
        //validation passed
        [Required(ErrorMessage ="Required Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        //validation passed
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        //validation passed
        [Required]
        [Range(1,5,ErrorMessage ="Enter In B/W 1 to 5")]
        public string Rating { get; set; }



    }
}
