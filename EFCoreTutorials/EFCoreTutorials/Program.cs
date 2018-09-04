using System;

//http://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx
namespace EFCoreTutorials
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {

                var std = new Student()
                {
                    Name = "Bill"
                };

                context.Students.Add(std);
                context.SaveChanges();
            }
            Console.ReadKey();

        }

    }
}
