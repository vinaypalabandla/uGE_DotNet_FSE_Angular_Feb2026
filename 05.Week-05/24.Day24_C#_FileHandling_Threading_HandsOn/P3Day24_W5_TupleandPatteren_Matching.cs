
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Sales Amount");
        int sales = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Rating (1-5): ");
        int rating = int.Parse(Console.ReadLine());

        var res = GetEmployeeData(sales, rating);

        string performance = res switch
        {
            ( >= 100000, >= 4) => "High Performer",
            ( >= 50000, >= 3) => "Average Performer",
            _ => "needs improvement"
        };

        Console.WriteLine("\nEmployee name: " + name);
        Console.WriteLine("Sales Amount: " + res.sales);
        Console.WriteLine("Rating: " + res.rating);
        Console.WriteLine("Performance: " + performance);
    }
    static (int sales, int rating) GetEmployeeData(int sales, int rating)
    {
        return (sales, rating);
    }
}