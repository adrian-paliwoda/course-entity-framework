using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using EfCodeFirstPluto.Model;

namespace EfCodeFirstPluto.SqlConfiguration
{
    public class PlutoContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        private static readonly string PathToDatabase = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..\\..\\")), "pluto.db");

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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}