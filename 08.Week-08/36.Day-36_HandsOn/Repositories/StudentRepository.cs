using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections;
using WebApplication6.Models;
namespace WebApplication6.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connStr;

        public StudentRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");

        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }
        public  IEnumerable<Student> GetStudentsWithCourse()
        {
            using (var db = GetConnection())
            {
                string sql = @"SELECT
                s.StudentId, s.StudentName, s.CourseId,
                c.CourseId, c.CourseName 
               FROM Students s
               INNER JOIN Courses c 
               ON s.CourseId = c.CourseId";
                return db.Query<Student, Course, Student>(
                                     sql,
                                    (stu, course) =>
                                    {
                                        stu.Course = course;
                                        return stu;
                                    },
                                    splitOn: "CourseId"
                                      );
                                
            }
        }

        public IEnumerable<Course> GetCoursesWithStudents()
        {
            using (var db = GetConnection())
            {
                string sql = @"SELECT
                c.CourseId, c.CourseName,
                s.StudentId, s.StudentName, s.CourseId
               FROM Courses c
               LEFT JOIN Students s 
               ON c.CourseId = s.CourseId";

                var dict = new Dictionary<int, Course>();

                var list = db.Query<Course, Student, Course>(
                    sql,
                    (course, student) =>
                    {
                        if (!dict.TryGetValue(course.CourseId, out var currentCourse))
                        {
                            currentCourse = course;
                            currentCourse.Students = new List<Student>();
                            dict.Add(currentCourse.CourseId, currentCourse);
                        }

                        if (student != null)
                        {
                            currentCourse.Students.Add(student);
                        }

                        return course;
                    },
                    splitOn: "StudentId"
                );

                return dict.Values;
            }
        }

    }
}
