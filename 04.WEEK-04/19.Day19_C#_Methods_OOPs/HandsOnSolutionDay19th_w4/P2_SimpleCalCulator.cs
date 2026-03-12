/*Level-1 Problem 1: Simple Calculator Using Methods
Scenario:
A small retail shop wants a simple calculator application to perform addition and subtraction operations using reusable methods.
Requirements:
1. Create a class named Calculator.
2. Create methods Add(int a, int b) and Subtract(int a, int b).
3. Each method should return the result.
4. In Main(), create an object and call the methods.
5. Display the output.
Technical Constraints:
1. Use method parameters and return types properly.
2. Use appropriate access modifiers.
3. No global variables allowed.
*/
class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public int Sub(int x, int y)
    {
        return x - y;
    }
    public int Mul(int x, int y)
    {
        return x * y;
    }
    public int Div(int x, int y)
    {
        return x / y;
    }
}
// now create main class 
class CalApp
{
    static void Main(string[] args)
    {
        //Object creation
        Calculator cal = new Calculator();

        Console.Write("Enter First Number: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("\nEnter Second Number: ");
        int y = int.Parse(Console.ReadLine());

        Console.WriteLine("\n=========Result Perfomring=========");

        Console.WriteLine("Addition: " + cal.Add(x, y));
        Console.WriteLine("Substract: " + cal.Sub(x, y));
        Console.WriteLine("Multiplication: " + cal.Mul(x, y));
        Console.WriteLine("Division: " + cal.Div(x, y));

    }
}