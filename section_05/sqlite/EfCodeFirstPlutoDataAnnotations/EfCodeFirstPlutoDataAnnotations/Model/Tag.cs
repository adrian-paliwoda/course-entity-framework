using System.Collections.Generic;

namespace EfCodeFirstPlutoDataAnnotations.Model
{
    public class Tag
    {
        public IList<Course> Courses { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}