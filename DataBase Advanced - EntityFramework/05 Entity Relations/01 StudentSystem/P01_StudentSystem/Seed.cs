namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Seed
    {
        public void SeedMethod()
        {
            using (var context = new StudentSystemContext())
            {
                AddCourse(context);
                AddStudents(context);
                AddStudentCourses(context);

                context.SaveChanges();
            }
        }

        private static void AddStudentCourses(StudentSystemContext context)
        {
            var JavaCourse = context.Courses.FirstOrDefault(x => x.Name == "Java");
            var JSCore = context.Courses.FirstOrDefault(x => x.Name == "JS Core");
            var CSharpOOP = context.Courses.FirstOrDefault(x => x.Name == "CSharpOOP");

            var student1 = context.Students.FirstOrDefault(x => x.Name == "Ivan Petrov");
            var student2 = context.Students.FirstOrDefault(x => x.Name == "Pesho Peshov");
            var student3 = context.Students.FirstOrDefault(x => x.Name == "Simona Simeonova");
            var student4 = context.Students.FirstOrDefault(x => x.Name == "Stavri Dinozavri");
            var student5 = context.Students.FirstOrDefault(x => x.Name == "Spiridon Kanchev");

            var studentCourses = new StudentCourse[]
            {
                new StudentCourse(student1, JavaCourse),
                new StudentCourse(student2, JavaCourse),
                new StudentCourse(student3, CSharpOOP),
                new StudentCourse(student4, CSharpOOP),
                new StudentCourse(student5, JSCore),
                new StudentCourse(student1, CSharpOOP),
                new StudentCourse(student2, JSCore),
                new StudentCourse(student2, CSharpOOP)
            };

            context.StudentCourses.AddRange(studentCourses);

        }

        private static void AddStudents(StudentSystemContext context)
        {
            DateTime birthday = new DateTime(1985, 06, 01);
            var students = new Student[] {
                new Student("Ivan Petrov", new DateTime(1985, 06, 01)),
                new Student("Pesho Peshov", new DateTime(1989, 06, 02)),
                new Student("Simona Simeonova", new DateTime(1990, 05, 24)),
                new Student("Stavri Dinozavri", new DateTime(1990, 05, 25)),
                new Student("Spiridon Kanchev", new DateTime(1991, 07, 07)),
                new Student("Chocho Chochov", new DateTime(1991, 07, 07)),
                new Student("Eli Stoykova", new DateTime(1992, 07, 07))
            };

            foreach (var student in students)
            {
                context.Students.Add(student);
            }

        }

        private static void AddCourse(StudentSystemContext context)
        {
            var JSCore = new Course();
            JSCore.Name = "JS Core";
            JSCore.Description = "One good course";
            JSCore.StartDate = new DateTime(2019, 01, 05);
            JSCore.EndDate = JSCore.StartDate.AddDays(30);
            JSCore.Price = 444.45m;

            var CSharpOOP = new Course();
            CSharpOOP.Name = "CSharpOOP";
            CSharpOOP.Description = "One good course";
            CSharpOOP.StartDate = new DateTime(2019, 01, 08);
            CSharpOOP.EndDate = JSCore.StartDate.AddDays(30);
            CSharpOOP.Price = 450.00m;

            var Java = new Course();
            Java.Name = "Java";
            Java.Description = "One good course";
            Java.StartDate = new DateTime(2019, 01, 20);
            Java.EndDate = JSCore.StartDate.AddDays(30);
            Java.Price = 490.00m;

            List<Course> courses = new List<Course>();
            courses.Add(JSCore);
            courses.Add(Java);
            courses.Add(CSharpOOP);

            for (int i = 0; i < courses.Count; i++)
            {
                context.Courses.Add(courses[i]);
            }
        }
    }
}
