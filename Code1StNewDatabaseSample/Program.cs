using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Code1StNewDatabaseSample
{
    class Program
    {
        static void Main()
        {
            using (var db= new StudentContext())
            {
                Console.WriteLine("Please enter your name:");
                var name=Console.ReadLine();
                Console.WriteLine("Please enter your last name:");
                var lname = Console.ReadLine();

                var Student =new Student() { Name = name,LastName=lname};
                db.Students.Add(Student);  
                db.SaveChanges();
                var query=from c in db.Students
                          orderby c.Name
                          select c;

            }

        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual List <Student>Students  { get; set; }
    }
    public class StudentContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

    }

}