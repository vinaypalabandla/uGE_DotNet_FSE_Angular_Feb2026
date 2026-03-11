/*Level-1 Problem 2: Simple Calculator Using Switch
Scenario
Create a simple calculator application that performs basic arithmetic operations.
Requirements
• Accept two numbers from user.
• Accept operator (+, -, *, /).
• Use switch statement to perform operation.
• Display result.
Technical Constraints
• Use int or double data types.
• Use switch-case statement.
• Handle division by zero.
Sample Input
Enter First Number: 10
Enter Second Number: 5
Enter Operator: *
Sample Output
Result: 50
Expectations
Correct operator selection and proper validation of inputs.
*/
using System;
class Calculator
{
    static void Main(string[] args)
    {
        Console.Write("Enter 1ST  Number: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Enter 2ND Number: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.Write("Enter Operator: ");
        char op = char.Parse(Console.ReadLine());

        switch (op)
        {
            case '+':
                Console.WriteLine("Result: " + (n1 + n2));
                break;
            case '-':
                Console.WriteLine("Result: " + (n1 - n2));
                break;
            case '*':
                Console.WriteLine("Result: " + (n1 * n2));
                break;
            case '/':
                if (n2 == 0)
                    Console.WriteLine("Cannot divide by zero");
                else
                    Console.WriteLine("Result: " + (n1 / n2));
                break;
            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}