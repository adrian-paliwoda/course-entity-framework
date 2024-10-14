using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EfCodeFirstPlutoChangeTracker.Model;
using EfCodeFirstPlutoChangeTracker.SqlConfiguration;

namespace EfCodeFirstPlutoChangeTracker.ChangeTracker
{
    public static class Changer
    {
        public static void Adding()
        {
            var context = new PlutoContext();

            var author = context.Authors.Single(a => a.Id == 1);
            var course = new Course
            {
                Name = "New Course",
                Description = "New Description",
                FullPrice = 19.34f,
                Level = 1,
                Author = author

                // new implicit new object in db so db create Mosh as new entry with id = 6 (for example)
                // Author = new Author() { Id = 1, Name = "Mosh Hamedani" }
            };

            context.Courses.AddOrUpdate(course);
            context.SaveChanges();

            var course1 = new Course
            {
                Name = "New Course",
                Description = "New Description",
                FullPrice = 19.34f,
                Level = 1,
                AuthorId = 1 // no additional query needed :)
            };

            context.Courses.AddOrUpdate(course1);
            context.SaveChanges();

            var authorToAttach = new Author { Id = 2 };
            context.Authors.Attach(authorToAttach);

            var course2 = new Course
            {
                Name = "New Course",
                Description = "New Description",
                FullPrice = 19.34f,
                Level = 1,
                Author = authorToAttach
            };

            context.Courses.AddOrUpdate(course2);
            context.SaveChanges();
        }

        public static void Updating()
        {
            var context = new PlutoContext();

            var course = context.Courses.Find(4); // Single(c => c.Id == 4)

            if (course != null)
            {
                course.Name = "New Name";
                course.AuthorId = 2;

                context.SaveChanges();
            }
        }

        public static void Delete()
        {
            var context = new PlutoContext();

            var course = context.Courses.Find(30);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public static void Delete1()
        {
            var context = new PlutoContext();

            var author = context.Authors
                                .Include(a => a.Courses)
                                .SingleOrDefault(a => a.Id == 2);

            if (author != null)
            {
                context.Courses.RemoveRange(author.Courses);
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }

        public static void ChangeTrackerStates()
        {
            var context = new PlutoContext();
            var author = context.Authors.Find(3);
            if (author != null)
            {
                author.Name = "Updated";
            }

            var anotherAuthor = context.Authors.Find(4);
            if (anotherAuthor != null)
            {
                context.Authors.Remove(anotherAuthor);
            }

            var entries = context.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                entry.Reload();
                Console.WriteLine(entry.State);
            }
        }
    }
}