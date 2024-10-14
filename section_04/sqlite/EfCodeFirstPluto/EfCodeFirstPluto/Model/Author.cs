using System.Collections.Generic;

namespace EfCodeFirstPluto.Model
{
    public class Author
    {
        public IList<Course> Courses { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}