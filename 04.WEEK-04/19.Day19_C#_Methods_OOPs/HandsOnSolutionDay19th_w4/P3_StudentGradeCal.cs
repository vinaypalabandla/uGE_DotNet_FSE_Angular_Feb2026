/*Level-1 Problem 2: Student Grade Calculator
Scenario:
A school wants to calculate the average marks of a student using a class-based approach.
Requirements:
1. Create a class Student.
2. Create method CalculateAverage(int m1, int m2, int m3).
3. Return the average marks.
4. Display grade based on average.
Technical Constraints:
1. Use return type double for average.
2. Avoid hard-coded values.
Expectations:
Clear separation of logic inside methods.
Learning Outcome:
Learn method creation, return values, and basic OOP concepts.
Sample Input: 
80 70 90
Sample Output: 
Average = 80, Grade = A
*/

//Create  a class
using System.Diagnostics;

class Student
{
    public double CalculateAvg(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3;
    }
    public char GetGrade(double avg)
    {
        if (avg >= 80)
        {
            return 'A';
        }
        else if (avg >= 60)
        {
            return 'B';
        }
        else if (avg >= 40)
        {
            return 'C';
        }
        else
        {
            return 'F';
        }

    }
    // main class
    class StudentApp
    {
        static void Main(string[] args)
        {
            //object creation
            Student sa = new Student();
            Console.WriteLine("\n==========**PLEASE ENTER THE MARKS**=================");
            Console.Write("Enter Marks m1: ");
            int m1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Marks m2: ");
            int m2 = int.Parse(Console.ReadLine());
            Console.Write("Enter Marks m3: ");
            int m3 = int.Parse(Console.ReadLine());

            double avg = sa.CalculateAvg(m1, m2, m3);
            Console.WriteLine("\n==========AVERAGE*SCORE=================");
            Console.WriteLine(avg);
            Console.WriteLine("\n==========GRADE=================");
            char grade = sa.GetGrade(avg);
            Console.WriteLine(grade);

            Console.WriteLine("\n=============AVERAGE MARKS WITH GRADE================");
            Console.WriteLine("Average = " + avg + ",Grade = " + grade);
        }
    }
}

