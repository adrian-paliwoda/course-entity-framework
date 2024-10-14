using System;
using System.Data.Entity;
using System.Linq;
using EfCodeFirstHomework.DbConfiguration;

namespace EfCodeFirstHomework.Exercises
{
    public static class LoadingExercise
    {
        public static void EagerLoad()
        {
            var context = new VidzyContext();

            var videos = context.Videos.Include(p => p.Genre).ToList();

            foreach (var video in videos)
            {
                Console.WriteLine(@"Name: {0} Genre {1}", video.Name, video.Genre.Name);
            }
        }
        
        public static void LoadMethod()
        {
            var context = new VidzyContext();

            var videos = context.Videos.ToList();
            
            context.Genres.Load();
            
            foreach (var video in videos)
            {
                Console.WriteLine(@"Name: {0} Genre {1}", video.Name, video.Genre.Name);
            }
        }
    }
}