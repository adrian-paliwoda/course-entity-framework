using System.Collections.Generic;

namespace EfCodeFirstPlutoChangeTracker.Model
{
    public class Tag
    {
        public virtual ICollection<Course> Courses { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Tag()
        {
            Courses = new HashSet<Course>();
        }
    }
}