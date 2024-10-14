using System;
using System.Collections.Generic;

namespace EfCodeFirstHomework.Model
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Classification Classification { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public HashSet<Tag> Tags { get; set; }

        public Video()
        {
            Tags = new HashSet<Tag>();
        }
    }
}