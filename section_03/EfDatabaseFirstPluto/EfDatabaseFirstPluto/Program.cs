using System;

namespace EfDatabaseFirstPluto
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new PlutoDbContext();
            
            var courses = dbContext.GetCourses();

            foreach (var cours in courses)
            {
                Console.WriteLine(cours.Title);
            }
        }
    }
}
