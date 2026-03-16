using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

class Product
{
    private string _name;
    private double _price;

    public string Name{ get; set; }
    public double Price
    {
        get { return _price; }
        set {
            if (value < 0)
            {
                Console.WriteLine("Price cannot be negative");
            }else { 
            _price = value; }
            }
    }

    public virtual double CalculateDiscount()
    {
        return Price;
    }
}

    class Electronic : Product {
        public override double CalculateDiscount()
        {
            double discount = Price * 0.05;
            return Price - discount;
        }

    }
    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            double discount = Price * 0.15;
            return Price - discount;
        }

    }
class Program
{
    static void Main(string[]args)
    {
    Product p = new Electronic();
        p.Name = "Mobile";
        p.Price = 20000;
      double  final =   p.CalculateDiscount();
        Console.WriteLine("Final Price after 5% discount =" + final);


    }
    
  
   

}