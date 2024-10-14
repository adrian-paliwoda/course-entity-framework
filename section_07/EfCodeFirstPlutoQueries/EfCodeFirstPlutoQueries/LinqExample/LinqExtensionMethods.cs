using System;
using System.Data.Entity;
using System.Linq;
using EfCodeFirstPlutoQueries.SqlConfiguration;

namespace EfCodeFirstPlutoQueries.LinqExample
{
    public static class LinqExtensionMethods
    {
        public static void Example()
        {
            var context = new PlutoContext();

            var query = context.Courses.Where(c => c.Name.Contains("C#")).OrderBy(c => c.Name);

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }
        }

        public static void MoreExamples()
        {
            var context = new PlutoContext();

            var query0 = context.Courses.Where(c => c.Level == 1);

            var query1 = context.Courses
                                .Where(c => c.Level == 1)
                                .OrderByDescending(c => c.Name)
                                .ThenBy(c => c.Level);

            var query2a = context.Courses
                                 .Where(c => c.Level == 1)
                                 .OrderByDescending(c => c.Name)
                                 .ThenBy(c => c.Level)
                                 .Select(c => new {CourseName = c.Name, AuthorName = c.Author.Name});

            var query2b = context.Courses
                                 .Where(c => c.Level == 1)
                                 .OrderByDescending(c => c.Name)
                                 .ThenBy(c => c.Level)
                                 .Select(c => c.Tags);

            foreach (var course in query2b)
            {
                foreach (var tag in course)
                {
                    Console.WriteLine(tag.Name);
                }
            }

            var query2c = context.Courses
                                 .Where(c => c.Level == 1)
                                 .OrderByDescending(c => c.Name)
                                 .ThenBy(c => c.Level)
                                 .SelectMany(c => c.Tags);

            Console.WriteLine();
            Console.WriteLine();
            foreach (var tag in query2c)
            {
                Console.WriteLine(tag.Name);
            }

            var query2d = context.Courses
                                 .Where(c => c.Level == 1)
                                 .OrderByDescending(c => c.Name)
                                 .ThenBy(c => c.Level)
                                 .SelectMany(c => c.Tags)
                                 .Distinct();

            Console.WriteLine();
            Console.WriteLine();
            foreach (var tag in query2d)
            {
                Console.WriteLine(tag.Name);
            }


            var query3 = context.Courses
                                .GroupBy(c => c.Level);

            Console.WriteLine();
            Console.WriteLine();
            foreach (var group in query3)
            {
                Console.WriteLine($"Key: {group.Key}");
                foreach (var course in group)
                {
                    Console.WriteLine($"\t{course.Name}");
                }
            }

            var query4a = context.Courses
                                 .Join(context.Authors,
                                     course => course.AuthorId,
                                     author => author.Id,
                                     (course, author) => new {CourseName = course.Name, AuthorName = author.Name});

            var query4b = context.Authors
                                 .GroupJoin(context.Courses,
                                     author => author.Id,
                                     course => course.AuthorId,
                                     (author, courses) => new {AuthorName = author.Name, Courses = courses});

            var query4c = context.Authors
                                 .SelectMany(a => context.Courses,
                                     (author, course) => new {AuthorName = author.Name, CourseName = course.Name});

            var query5 = context.Courses.Skip(10).Take(10);
            
            var query6a = context.Courses.OrderBy(c => c.Level).First();
            var query6b = context.Courses.OrderBy(c => c.Level).FirstOrDefault(p => p.FullPrice > 100);
            var query6c = context.Courses.LastOrDefault();
            var query6d = context.Courses.SingleOrDefault(c => c.Id == 1);

            var query7a = context.Courses.All(p => p.FullPrice > 10);
            var query7b = context.Courses.Any(p => p.Level == 1);

            var query8a = context.Courses.Count();
            var query8b = context.Courses.Max(course => course.FullPrice);
            var query8c = context.Courses.Min(course => course.FullPrice);
            var query8d = context.Courses.Average(course => course.FullPrice);
            
        }
    }
}