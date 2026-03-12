/*Assignment
 ~~~~~~~~~~~~~~
  
 Write  a  C# program to process product details using object oriented programming.
 
•	Class should contain private variables:  productId, productName, unitPrice, qty.
•	Constructor should allow productId as parameter
•	 Create properties for all private variables. Property Names :   ProductId, ProductName, UnitPrice, Quantity
•	ProductId – should be readonly property
•	ShowDetails()  method to display all the details along with total amount.*/
using System;
class Prodcut
{
    //private variables
    private int _prodcutId;
    private string _productName;
    private double _unitPrice;
    private int _productQuantity;

    // Constructor with productId parameter
    public Prodcut(int id)
    {
        _prodcutId = id;
    }
    // Readonly Property
    public int ProdcutId
    {
        get { return _prodcutId; }
    }
    //Property writing
    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }
    public double UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }
    public int ProductQuantity
    {
        get { return _productQuantity; }
        set { _productQuantity = value; }
    }

    public void ShowDetails() //method  name 
    {
        double total = _unitPrice * _productQuantity;

        Console.WriteLine("Product ID: " + ProdcutId);
        Console.WriteLine("Product Name: " + ProductName);
        Console.WriteLine("UnitPrice: " + UnitPrice);
        Console.WriteLine("Product Quantity: " + ProductQuantity);
        Console.WriteLine("Total Amount: " + total);

    }

}

class MainProgram
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter Prodcut ID: ");
        int id = int.Parse(Console.ReadLine());

        Prodcut p = new Prodcut(id);

        Console.WriteLine("Enter Product Name: ");
        p.ProductName = Console.ReadLine();
        Console.WriteLine("Enter Unit Price: ");
        p.UnitPrice = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Prodcut Quantity: ");
        p.ProductQuantity = int.Parse(Console.ReadLine());

        Console.WriteLine("\nProdcut Details:  ");
        p.ShowDetails();

    }
}