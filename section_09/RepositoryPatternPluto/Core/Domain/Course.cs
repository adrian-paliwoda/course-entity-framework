using System.Collections.Generic;

namespace Core.Domain
{
    public class Course
    {
        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        public Cover Cover { get; set; }

        public string Description { get; set; }

        public float FullPrice { get; set; }

        public int Id { get; set; }

        public bool IsBeginnerCourse => Level == 1;

        public int Level { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Course()
        {
            Tags = new HashSet<Tag>();
        }
    }
}