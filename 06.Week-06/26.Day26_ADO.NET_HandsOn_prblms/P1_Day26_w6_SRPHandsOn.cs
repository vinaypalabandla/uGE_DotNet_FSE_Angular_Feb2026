using System;
using System.Collections.Generic;

namespace SRPHandsOnExample
{
        //create Student Class
     class Student
    {
       //auto properties
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }

    }
    //create StudentRespository class
    class StudentRespository
    {
        //create Student Object store in list using private it acces inside class
       private List<Student> stu = new List<Student>();
        public void AddStudent(Student student)
        {
            stu.Add(student);//adds student object in list
        }
        public List<Student> GetAllStudents() // method return retrun all stuudnets
        {
            return stu;// return list
        }
    }
    // create class for RepostGenerator
    class ReportGenerator
    {
        public void GenarateReport(List<Student> stu)
        {
            Console.WriteLine("==========Student Report======");
            foreach (var student in stu)
            {
                Console.WriteLine("ID: " + student.StudentId);
                Console.WriteLine("Name: " + student.StudentName);
                Console.WriteLine("Marks: " + student.Marks);
            }
        } 
    }


    //Main Program
    class Program
    {
        static void Main(string[] args)
        {
            //creating object for StudentRepository class
            StudentRespository repo = new StudentRespository();
            // create object for ReportGenerator class
            ReportGenerator report =  new ReportGenerator();

            repo.AddStudent(new Student { StudentId = 1, StudentName = "vinay", Marks = 84 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "vinayKumar", Marks = 75});

            var students = repo.GetAllStudents();
            //Sends data to report generator to print
            report.GenarateReport(students);

            Console.ReadLine();

        }
    }

}