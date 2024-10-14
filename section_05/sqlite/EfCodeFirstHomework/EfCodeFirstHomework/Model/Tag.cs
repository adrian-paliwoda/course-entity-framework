using System.Collections.Generic;

namespace EfCodeFirstHomework.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Video> Videos { get; set; }

        public Tag()
        {
            Videos = new List<Video>();
        }
    }
}