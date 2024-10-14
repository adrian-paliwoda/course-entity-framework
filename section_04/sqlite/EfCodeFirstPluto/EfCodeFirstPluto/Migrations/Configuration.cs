using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EfCodeFirstPluto.Model;
using EfCodeFirstPluto.SqlConfiguration;

namespace EfCodeFirstPluto.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PlutoContext context)
        {
            context.Authors.AddOrUpdate(p => p.Name,
                new Author
                {
                    Name = "Author 1",
                    Courses = new Collection<Course>
                    {
                        new Course
                        {
                            Name = "Course for Author 1", Description = "Description"
                        }
                    }
                });
        }
        
    }
}