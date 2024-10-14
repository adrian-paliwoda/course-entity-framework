using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EfCodeFirstHomework.DbConfiguration;
using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.Exercises
{
    public static class Updating
    {
        public static void Exercise_1()
        {
            using (var context = new VidzyContext())
            {
                var actionGenre = context.Genres.FirstOrDefault(g => g.Name.Equals("Action"));
                var idGenre = actionGenre?.Id ?? 2;

                var terminator = new Video
                {
                    Name = "Terminator 1",
                    GenreId = idGenre,
                    Classification = Classification.Gold,
                    ReleaseDate = new DateTime(1984, 10, 26)
                };

                context.Videos.AddOrUpdate(p => p.Name, terminator);
                context.SaveChanges();
            }
        }

        public static void Exercise_2()
        {
            using (var context = new VidzyContext())
            {
                var classicsTag = new Tag { Name = "Classics" };
                var dramaTag = new Tag { Name = "Drama" };

                context.Tags.AddOrUpdate(p => p.Name, classicsTag);
                context.Tags.AddOrUpdate(p => p.Name, dramaTag);

                context.SaveChanges();
            }
        }

        public static void Exercise_3()
        {
            using (var context = new VidzyContext())
            {
                var tagsToAdd = new[] { "Comedy", "Drama", "Classics" };
                var tagsFromDb = context.Tags.Where(p => tagsToAdd.Contains(p.Name)).ToList();

                foreach (var tag in tagsToAdd)
                {
                    if (!tagsFromDb.Any(p => p.Name.Equals(tag)))
                    {
                        context.Tags.Add(new Tag { Name = tag });
                    }
                }
                context.SaveChanges();

                var tags = context.Tags.Where(p => tagsToAdd.Contains(p.Name));
                var godfather = context.Videos
                                       .Include(p => p.Tags)
                                       .SingleOrDefault(v => v.Name.Equals("The Godfather"));
                
                if (godfather != null)
                {
                    foreach (var tag in tags)
                    {
                        if (!godfather.Tags.Any(p => p.Name.Equals(tag.Name)))
                        {
                            godfather.Tags.Add(tag);
                        }
                    }
                }

                context.SaveChanges();
            }
        }

        public static void Exercise_4()
        {
            using (var context = new VidzyContext())
            {
                var godfather = context.Videos
                                       .Include(v => v.Tags)
                                       .SingleOrDefault(p => p.Name.Equals("The Godfather"));


                if (godfather != null && godfather.Tags.Any(p => p.Name.Equals("Comedy")))
                {
                    godfather.Tags
                             .RemoveWhere(p => p.Name.Equals("Comedy"));

                    context.SaveChanges();
                }
            }
        }

        public static void Exercise_5()
        {
            using (var context = new VidzyContext())
            {
                var godfather = context.Videos
                                       .SingleOrDefault(p => p.Name.Equals("The Godfather"));

                if (godfather != null)
                {
                    context.Videos.Remove(godfather);
                    context.SaveChanges();
                }
            }
        }

        public static void Exercise_6()
        {
            using (var context = new VidzyContext())
            {
                var videos = context.Videos
                                    .Where(p => p.Genre.Name.Equals("Action"));

                context.Videos.RemoveRange(videos);

                var actionGenre = context.Genres.SingleOrDefault(g => g.Name.Equals("Action"));
                if (actionGenre != null)
                {
                    context.Genres.Remove(actionGenre);
                }

                context.SaveChanges();
            }
        }
    }
}