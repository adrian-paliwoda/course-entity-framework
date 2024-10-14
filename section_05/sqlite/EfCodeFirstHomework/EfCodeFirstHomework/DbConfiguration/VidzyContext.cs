using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using EfCodeFirstHomework.EntityConfigurations;
using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.DbConfiguration
{
    public class VidzyContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }

        private static readonly string PathToDatabase = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..\\..\\")), "vidzy.db");

        public VidzyContext()
            : base(new SQLiteConnection
            {
                ConnectionString = new SQLiteConnectionStringBuilder
                    {DataSource = PathToDatabase, ForeignKeys = true}.ConnectionString
            }, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}