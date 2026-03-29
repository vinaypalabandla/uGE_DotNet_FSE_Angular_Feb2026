
// 2.  Create ASP.NET Core -  MVC Application to process product details 
// 			a.   Index 	---	to display collection of products 
// 			b.   Details ---  to display  single product information 
			


namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
