﻿namespace EfCodeFirstHomework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genres (Name) VALUES('Drama')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
