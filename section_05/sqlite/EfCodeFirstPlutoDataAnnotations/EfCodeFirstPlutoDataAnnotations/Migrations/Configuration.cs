
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EfCodeFirstPlutoDataAnnotations.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EfCodeFirstPlutoDataAnnotations.SqlConfiguration.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}