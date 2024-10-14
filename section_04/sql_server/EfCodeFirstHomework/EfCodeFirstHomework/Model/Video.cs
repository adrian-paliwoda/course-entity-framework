using System;
using System.Collections.Generic;

namespace EfCodeFirstHomework.Model
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Classiﬁcation Classiﬁcation { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
    }
}
