using System;
using System.Linq;
using EfCodeFirstPlutoQueries.SqlConfiguration;

namespace EfCodeFirstPlutoQueries.LoadingRelatedObjects
{
    public static class LazyLoading
    {
        public static void Example()
        {
            var context = new PlutoContext();

            var course = context.Courses.Single(c => c.Id == 2);

            foreach (var tag in course.Tags)
            {
                Console.WriteLine(tag.Name);
            }
        }
    }
}