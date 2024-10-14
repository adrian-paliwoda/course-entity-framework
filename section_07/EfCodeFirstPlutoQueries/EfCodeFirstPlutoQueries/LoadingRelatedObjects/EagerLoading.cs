using System;
using System.Data.Entity;
using System.Linq;
using EfCodeFirstPlutoQueries.SqlConfiguration;

namespace EfCodeFirstPlutoQueries.LoadingRelatedObjects
{
    public static class EagerLoading
    {
        public static void Example()
        {
            var context = new PlutoContext();
            var courses = context.Courses
              //                   .Include(p => p.Author)
                                 .Include(p => p.Tags.Select(c => c.Courses)) //only for demonstration
                                 .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine(@"{0} by {1}", course.Name, course.Author.Name);
            }
        }
    }
}