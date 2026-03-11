//Scenario
//You are developing a console-based application in .NET 8 for a school. The application should evaluate a student’s marks and assign a grade based on predefined rules.
//Requirements
//• Accept student name and marks (0-100).
//• Use if-else statements to determine grade.
//• Display grade as A, B, C, D or Fail.
//• Handle invalid input using conditional checks.
//Technical Constraints
//• Use C# (.NET 8 Console Application).
//• Use appropriate data types (string, int).
//• Use if-else control flow.
//• Do not use advanced concepts like classes or LINQ.
//Sample Input
//Enter Name: Rahul
//Enter Marks: 78
//Sample Output
//Student: Rahul
//Grade: B
//Expectations
//Program should correctly evaluate grade and handle edge cases like marks below 0 or above 100.
using System;

namespace ConsoleApp4
{
    internal class StudentGrade
    {
        static void Main(string[]args)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks");
            }
            else if (marks >= 90)
            {
                Console.WriteLine($"Student: {name}");
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 75)
            {
                Console.WriteLine($"Student: {name}");
                Console.WriteLine("Grade: B");
            }
            else if (marks >= 60)
            {
                Console.WriteLine($"Student: {name}");
                Console.WriteLine("Grade: C");
            }
            else if (marks >= 40)
            {
                Console.WriteLine($"Student: {name}");
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine($"Student: {name}");
                Console.WriteLine("Grade: Fail");
            }
        }
    }
}