using System.Collections.Generic;

namespace EfCodeFirstHomework.Model
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Video> Videos { get; set; }

        public Genre()
        {
            Videos = new List<Video>();
        }
    }
}