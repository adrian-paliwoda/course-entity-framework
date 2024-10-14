using System.Collections.Generic;

namespace EfCodeFirstPlutoFluentAPI.Model
{
    public class Tag
    {
        public IList<Course> Courses { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}