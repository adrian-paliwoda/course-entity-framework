﻿namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Categories (Name) VALUES('Web Developer')");
            Sql("INSERT INTO Categories (Name) VALUES('Programming languages')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
