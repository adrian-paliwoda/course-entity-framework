using System.Collections.Generic;

namespace EfCodeFirstPlutoChangeTracker.Model
{
    public class Author
    {
        public virtual ICollection<Course> Courses { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Author()
        {
            Courses = new HashSet<Course>();
        }
    }
}