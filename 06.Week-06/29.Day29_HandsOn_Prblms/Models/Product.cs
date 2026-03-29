

//1.Create ASP.NET Core MVC Application to perform CRUD operations on Products Data.    Create required Model Class, Controller and Action methods. 

//2.  Update the above example with the following requirements:
//			---use data annotations for validations
//			---  Validations:
//						product id --required 
//						product name -- required, length should be 5 to 15
//						price --    required 
//						category ---   length should be 5 to 15

    
    using System.ComponentModel.DataAnnotations;

    namespace WebApplication2.Models
    {
        public class Product
        {
            [Required(ErrorMessage = "Product ID is required")]
            public int ProductId { get; set; }

            [Required(ErrorMessage = "Product Name is required")]
            [StringLength(15, MinimumLength = 5, ErrorMessage = "Name must be 5 to 15 characters")]
            public string ProductName { get; set; }

            [Required(ErrorMessage = "Price is required")]
            public decimal Price { get; set; }

            [StringLength(15, MinimumLength = 5, ErrorMessage = "Category must be 5 to 15 characters")]
            public string Category { get; set; }
        
    }
}
