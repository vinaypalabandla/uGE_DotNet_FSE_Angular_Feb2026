/*Level-2 Problem 1: Employee Bonus Calculator
Scenario
Develop a console application that calculates employee bonus based on salary and years of experience.
Requirements
• Accept employee name, salary and years of experience.
• Use if-else and conditional operator.
• Bonus rules:
   - Experience < 2 years: 5% bonus
   - 2-5 years: 10% bonus
   - >5 years: 15% bonus
• Display final salary after bonus.
Technical Constraints
• Use double for salary.
• Use if-else and ternary operator.
• Use proper formatting for currency output.
Sample Input
Enter Name: Aisha
Enter Salary: 50000
Enter Experience: 4
Sample Output
Employee: Aisha
Bonus: 5000
Final Salary: 55000
Expectations
Accurate bonus calculation and correct usage of control statements.
*/
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double sal = double.Parse(Console.ReadLine());

        Console.Write("Enter Experience: ");
        int exp = int.Parse(Console.ReadLine());

        double bonusPer;

        if (exp < 2)
        {
            bonusPer = 0.05;
        }
        else if (exp <= 5)
        {
            bonusPer = 0.10;
        }
        else
        {
            bonusPer = 0.15;
        }
       // double bonus = (exp >= 0) ? sal * bonusPer:0;
        double bonus = sal * bonusPer;
        double finalSal = sal+bonus;

        Console.WriteLine($"Employee: {name}");
        Console.WriteLine($"Bonus: {bonus}");
        Console.WriteLine($"Final Salary: {finalSal}");
    }
}