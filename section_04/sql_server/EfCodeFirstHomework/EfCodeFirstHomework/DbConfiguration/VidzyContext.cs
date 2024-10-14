using EfCodeFirstHomework.Model;
using System.Data.Entity;

namespace EfCodeFirstHomework.DbConfiguration
{
    public class VidzyContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }

        public VidzyContext()
            : base("name=DefaultConnection")
        {

        }
    }
}
