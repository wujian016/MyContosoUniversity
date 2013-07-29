namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContosoUniversity.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoUniversity.Models.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            

            context.Students.AddOrUpdate(
                  p => new { p.FirstMidName, p.LastName },
                   new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
                );

            /*
            context.Instructors.AddOrUpdate(
                p => new { p.FirstMidName, p.LastName },
                new Instructor { FirstMidName = "Kim", LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Fadi", LastName = "Fakhouri", HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Roger", LastName = "Harui", HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Candace", LastName = "Kapoor", HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Roger", LastName = "Zheng", HireDate = DateTime.Parse("2004-02-12") }
                        );
             */

            var instructors = new[]
                {
                   new Instructor{FirstMidName = "Kim", LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11")},
                   new Instructor { FirstMidName = "Fadi", LastName = "Fakhouri", HireDate = DateTime.Parse("2002-07-06") },
                    new Instructor { FirstMidName = "Roger", LastName = "Harui", HireDate = DateTime.Parse("1998-07-01") },
                    new Instructor { FirstMidName = "Candace", LastName = "Kapoor", HireDate = DateTime.Parse("2001-01-15") },
                    new Instructor { FirstMidName = "Roger", LastName = "Zheng", HireDate = DateTime.Parse("2004-02-12") }
                };

            context.OfficeAssignments.AddOrUpdate(
                p => p.Location,
                new OfficeAssignment { InstructorID = 1, Location = "Smith 17" },
                new OfficeAssignment { InstructorID = 2, Location = "Gowan 27" },
                new OfficeAssignment { InstructorID = 3, Location = "Thompson 304" }
            );

            context.Departments.AddOrUpdate(
                      P=>P.Name,
                new Department { Name = "English", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), Administrator = context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Kim" && s.LastName == "Abercrombie") },
                new Department { Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), Administrator = context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Fadi" && s.LastName == "Fakhouri") },
                new Department { Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), Administrator = context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Roger" && s.LastName == "Harui") },
                new Department { Name = "Economics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), Administrator = context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Candace" && s.LastName == "Kapoor") }        
                     );

            context.Courses.AddOrUpdate(
    p => p.Title,
    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Engineering"), Instructors = new[] { instructors[0], instructors[1] } },
    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Economics"), Instructors = new[] { instructors[2] } },
    new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Economics"), Instructors = new[] { instructors[2] } },
    new Course { CourseID = 1045, Title = "Calculus", Credits = 4, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Mathematics"), Instructors = new[] { instructors[3] } },
    new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Mathematics"), Instructors = new[] { instructors[3] } },
    new Course { CourseID = 2021, Title = "Composition", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "English"), Instructors = new[] { instructors[3] } },
    new Course { CourseID = 2042, Title = "Literature", Credits = 4, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "English"), Instructors = new[] { instructors[3] } }
  );
           
            /*
            context.Courses.AddOrUpdate(
                p => p.Title,
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Engineering"), Instructors = {context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Kim" && s.LastName == "Abercrombie"), context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Fadi" && s.LastName == "Fakhouri") } },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Economics"), Instructors = { context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Roger" && s.LastName == "Harui") } },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Economics"), Instructors = { context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Roger" && s.LastName == "Harui") } },
                new Course { CourseID = 1045, Title = "Calculus", Credits = 4, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Mathematics"), Instructors = { context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Roger" && s.LastName == "Zheng") } },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "Mathematics"), Instructors = { context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Roger" && s.LastName == "Zheng") } },
                new Course { CourseID = 2021, Title = "Composition", Credits = 3, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "English"), Instructors = { context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Roger" && s.LastName == "Zheng") } },
                new Course { CourseID = 2042, Title = "Literature", Credits = 4, Department = context.Departments.Local.SingleOrDefault(s => s.Name == "English"), Instructors = { context.Instructors.Local.SingleOrDefault(s => s.FirstMidName == "Roger" && s.LastName == "Zheng") } }
              );
             */

            context.Enrollments.AddOrUpdate(
             p => new { p.StudentID, p.EnrollmentID },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Carson" && s.LastName == "Alexander"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Chemistry"), Grade = 1 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Carson" && s.LastName == "Alexander"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Microeconomics"), Grade = 3 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Carson" && s.LastName == "Alexander"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Macroeconomics"), Grade = 1 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Meredith" && s.LastName == "Alonso"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Calculus"), Grade = 2 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Meredith" && s.LastName == "Alonso"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Trigonometry"), Grade = 4 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Meredith" && s.LastName == "Alonso"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Composition"), Grade = 4 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Arturo" && s.LastName == "Anand"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Chemistry"), CourseID = 1 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Gytis" && s.LastName == "Barzdukas"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Chemistry"), },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Gytis" && s.LastName == "Barzdukas"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Microeconomics"), Grade = 4 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Yan" && s.LastName == "Li"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Macroeconomics"), Grade = 3 },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Peggy" && s.LastName == "Justice"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Calculus") },
                 new Enrollment { Student = context.Students.Local.SingleOrDefault(s => s.FirstMidName == "Laura" && s.LastName == "Norman"), Course = context.Courses.Local.SingleOrDefault(c => c.Title == "Trigonometry"), Grade = 2 }
                );
            
        }
    }
}
