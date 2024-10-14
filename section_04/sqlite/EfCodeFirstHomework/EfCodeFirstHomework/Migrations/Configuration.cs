
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EfCodeFirstHomework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EfCodeFirstHomework.DbConfiguration.VidzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}