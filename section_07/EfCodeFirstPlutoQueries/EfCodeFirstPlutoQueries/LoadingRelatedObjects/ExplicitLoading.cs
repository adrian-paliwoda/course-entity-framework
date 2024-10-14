using System;
using System.Data.Entity;
using System.Linq;
using EfCodeFirstPlutoQueries.SqlConfiguration;

namespace EfCodeFirstPlutoQueries.LoadingRelatedObjects
{
    public static class ExplicitLoading
    {
        public static void Example()
        {
            var context = new PlutoContext();

            var author = context.Authors.Single(a => a.Id == 1);

            // MSDN way
            context.Entry(author)
                   .Collection(a => a.Courses)
                   .Query()
                   .Where(c => Math.Abs(c.FullPrice - 49) < 0.1)
                   .Load();

            // Other way
            context.Courses.Where(c => c.AuthorId == author.Id && Math.Abs(c.FullPrice - 49) < 0).Load();
            
            foreach (var course in author.Courses)
            {
                Console.WriteLine(course.Name);
            }


            var authors = context.Authors.ToList();
            var authorIds = authors.Select(a => a.Id);

            context.Courses.Where(c => authorIds.Contains(c.Id) && Math.Abs(c.FullPrice - 49) < 0).Load();
        }
    }
}