using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCodeFirstPlutoDataAnnotations.Model
{
    public class Course
    {
        public Author Author { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public float FullPrice { get; set; }
        public int Id { get; set; }
        public CourseLevel Level { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}