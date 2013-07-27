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

            context.Courses.AddOrUpdate(
                p => p.Title,
                new Course { Title = "Chemistry", Credits = 3, },
                new Course { Title = "Microeconomics", Credits = 3, },
                new Course { Title = "Macroeconomics", Credits = 3, },
                new Course { Title = "Calculus", Credits = 4, },
                new Course { Title = "Trigonometry", Credits = 4, },
                new Course { Title = "Composition", Credits = 3, },
                new Course { Title = "Literature", Credits = 4, }
              );


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
