using System.Collections.Generic;

namespace EfCodeFirstPlutoFluentAPI.Model
{
    public class Course
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
        public float FullPrice { get; set; }
        public int Id { get; set; }
        public CourseLevel Level { get; set; }
        public string Name { get; set; }
        public IList<Tag> Tags { get; set; }
        public Cover Cover { get; set; }
    }
}