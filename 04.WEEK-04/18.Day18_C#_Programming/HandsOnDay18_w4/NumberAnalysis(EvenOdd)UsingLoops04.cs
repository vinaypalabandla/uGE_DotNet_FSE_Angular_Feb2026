/*Level-2 Problem 2: Number Analysis Using Loops
Scenario
Create a .NET 8 console application that analyzes numbers between 1 and N.
Requirements
• Accept a number N from user.
• Use loops to:
   - Count even numbers
   - Count odd numbers
   - Calculate sum of all numbers
• Display results.
Technical Constraints
• Use for or while loop.
• Use int data type.
• Avoid using arrays or collections.
Sample Input
Enter Number: 10
Sample Output
Even Count: 5
Odd Count: 5
Sum: 55
Expectations
Proper loop usage and correct counting logic.
*/
using System;
namespace ConsoleApp7
{
   internal class EvenAndOddCount
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number: ");
            int num = int.Parse(Console.ReadLine());

            int evenCount = 0,oddCount=0,sum=0;
            //int i=1;
            for (int i = 1; i <= num;i++)
            {
                sum = sum+ i;

                if (i % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
            //while (i <= N)
            //{
            //    sum += i;

            //    if (i % 2 == 0)
            //        evenCount++;
            //    else
            //        oddCount++;

            //    i++;
            //}
            Console.WriteLine($"Even Count: {evenCount}");
            Console.WriteLine($"Odd Count: {oddCount}");
            Console.WriteLine($"Sum: {sum}");
        }
    }

}
