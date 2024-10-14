using System.Collections.Generic;

namespace Core.Domain
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