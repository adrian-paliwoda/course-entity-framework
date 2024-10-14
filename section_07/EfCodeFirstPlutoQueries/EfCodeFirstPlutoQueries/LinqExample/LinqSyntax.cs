using System;
using System.Linq;
using EfCodeFirstPlutoQueries.SqlConfiguration;

namespace EfCodeFirstPlutoQueries.LinqExample
{
    public static class LinqSyntax
    {
        public static void Example()
        {
            var context = new PlutoContext();

            var query =
                from c in context.Courses
                where c.Name.Contains("C#")
                orderby c.Name
                select c;

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }
        }

        public static void MoreExamples()
        {
            var context = new PlutoContext();

            var query0 =
                from c in context.Courses
                where c.Level == 1 && c.Author.Id == 1
                select c;

            var query1 =
                from c in context.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select c;

            var query2 =
                from c in context.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select new {c.Name, Author = c.Author.Name};

            var query3 =
                from c in context.Courses
                group c by c.Level
                into g
                select g;

            foreach (var group in query3)
            {
                Console.WriteLine("{0} ({1})", group.Key, group.Count());
                foreach (var course in group)
                {
                    Console.WriteLine($"\t{course.Name}");
                }
            }


            var query4a =
                from c in context.Courses
                select new {CourseName = c.Name, AuthorName = c.Author.Name};

            var query4b =
                from c in context.Courses
                join author in context.Authors on c.AuthorId equals author.Id
                select new {CourseName = c.Name, AuthorName = author.Name};


            var query4c =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId into g
                select new {AuthorName = a.Name, Courses = g.Count()};

            Console.WriteLine();
            Console.WriteLine();
            foreach (var author in query4c)
            {
                Console.WriteLine($@"{author.AuthorName} ({author.Courses})");
            }


            var query4d =
                from a in context.Authors
                from c in context.Courses
                select new {AuthorName = a.Name, CourseName = c.Name};

            foreach (var x in query4d)
            {
                Console.WriteLine("{0} - {1}", x.AuthorName, x.CourseName);
            }
        }
    }
}