using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using EfCodeFirstPlutoFluentAPI.EntityConfigurations;
using EfCodeFirstPlutoFluentAPI.Model;

namespace EfCodeFirstPlutoFluentAPI.SqlConfiguration
{
    public class PlutoContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        private static readonly string PathToDatabase = Path
            .Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..\\..\\")), "plutoFluentAPI.db");

        public PlutoContext()
            : base(new SQLiteConnection
            {
                ConnectionString = new SQLiteConnectionStringBuilder
                    {DataSource = PathToDatabase, ForeignKeys = true}.ConnectionString
            }, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
    
}