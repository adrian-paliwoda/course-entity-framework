using System.Data.Entity.Migrations;

namespace EfCodeFirstPlutoFluentAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EfCodeFirstPlutoFluentAPI.SqlConfiguration.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}