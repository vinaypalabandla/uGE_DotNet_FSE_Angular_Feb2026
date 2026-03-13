using HRSystem;
class Program
{
    static void Main(String[] args)
    {
        Employee emp = new Employee("Marko Horvat", 4500, 35);
        Console.WriteLine("Name: " + emp.FullName);
        Console.WriteLine("Age: " + emp.Age);
        Console.WriteLine("Salary: " + emp.Salary);

        emp.GiveRaise(15);

        Console.WriteLine("Salary after raise: " + emp.Salary);

        bool result = emp.DeductPenalty(500);

        Console.WriteLine("Penalty Applied: " + result);
        Console.WriteLine("Final Salary: " + emp.Salary);

        emp.FullName = "Marko Horvat Jr.";
        Console.WriteLine("Updated Name: " + emp.FullName);
    }
}
