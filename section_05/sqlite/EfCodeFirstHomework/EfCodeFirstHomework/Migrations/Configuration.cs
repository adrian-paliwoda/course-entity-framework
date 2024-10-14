using System.Data.Entity.Migrations;
using EfCodeFirstHomework.DbConfiguration;

namespace EfCodeFirstHomework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VidzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}