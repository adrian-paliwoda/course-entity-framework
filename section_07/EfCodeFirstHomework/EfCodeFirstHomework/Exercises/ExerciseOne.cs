using System;
using System.Linq;
using EfCodeFirstHomework.DbConfiguration;
using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.Exercises
{
    public static class ExerciseOne
    {
        public static void All()
        {
            var context = new VidzyContext();

            var actionMoviesSortedByName =
                context.Videos
                       .Where(p => p.Genre.Name.Equals("Action"))
                       .OrderBy(v => v.Name);

            foreach (var video in actionMoviesSortedByName)
            {
                Console.WriteLine(video.Name);
            }

            var goldDramaMovies =
                context.Videos
                       .Where(v => v.Classification == Classification.Gold && v.Genre.Name.Equals("Drama"))
                       .OrderByDescending(p => p.ReleaseDate);

            Console.WriteLine();
            Console.WriteLine();
            foreach (var dramaMovie in goldDramaMovies)
            {
                Console.WriteLine(dramaMovie.Name);
            }

            var allMovies = context.Videos.Select(video => new { MovieName = video.Name, Genre = video.Genre.Name });

            Console.WriteLine();
            Console.WriteLine();
            foreach (var movie in allMovies)
            {
                Console.WriteLine(movie.MovieName);
            }

            var moviesByClassification = context.Videos
                                                .GroupBy(v => v.Classification)
                                                .Select(v => new {Classification = v.Key, Movies = v});

            Console.WriteLine();
            Console.WriteLine();
            foreach (var group in moviesByClassification)
            {
                Console.WriteLine($@"Classification: ({group.Classification})");
                foreach (var video in group.Movies.OrderBy(p => p.Name))
                {
                    Console.WriteLine(video.Name);
                }
            }


            var classifications = context.Videos
                                       .GroupBy(p => p.Classification)
                                       .Select(c => new { Classification = c.Key, Count = c.Count() });

            Console.WriteLine();
            Console.WriteLine();
            foreach (var classification in classifications)
            {
                Console.WriteLine($"{classification.Classification} ({classification.Count})");
            }

            var genres = context.Genres
                                .GroupJoin(context.Videos, genre => genre.Id, video => video.GenreId,
                                    (genre, videos) => new { GenreName = genre.Name, Count = videos.Count() })
                                .OrderByDescending(p => p.Count);

            Console.WriteLine();
            Console.WriteLine();
            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.GenreName} ({genre.Count})");
            }
        }
    }
}