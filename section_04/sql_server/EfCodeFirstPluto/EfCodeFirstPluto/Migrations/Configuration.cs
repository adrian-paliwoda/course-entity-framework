namespace EfCodeFirstPluto.Migrations
{
    using EfCodeFirstPluto.Model;
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EfCodeFirstPluto.DbConfiguration.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EfCodeFirstPluto.DbConfiguration.PlutoContext context)
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
