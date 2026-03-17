using System;

public record Student(int RollNumber, String Name, string Course, int Marks);

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Enter number of students: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Student[] stu = new Student[n]; // arralist store n students
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter  Name: ");
            String name = Console.ReadLine();
            Console.WriteLine($"Enter Course: ");
            String course = Console.ReadLine();
            Console.WriteLine($"Enter marks: ");
            int marks = int.Parse(Console.ReadLine());

            stu[i] = new Student(roll, name, course, marks); // create student object store in array positon i
            Console.WriteLine();
        }

        Console.WriteLine("\nStudent Recorrds: ");
        foreach (Student st in stu)
        {
            Console.WriteLine("Roll No: " + st.RollNumber + " | Name: " + st.Name + "| Course: " + st.Course + "| Marks: " + st.Marks);
        }

        Console.WriteLine("\nSearch Roll Number: ");
        int searchRoll = int.Parse(Console.ReadLine());
        bool found = false;
        foreach (Student st in stu)
        {
            Console.WriteLine("\nStudent Found: ");
            Console.WriteLine("Roll No: " + st.RollNumber + " | Name: " + st.Name + " | Course: " + st.Course + " | Marks: " + st.Marks);
            found = true;
            break;
        }
        if(found == false)
        {
            Console.WriteLine("\n Student not found: ");
        }

        Console.ReadLine();
    }
    
}
