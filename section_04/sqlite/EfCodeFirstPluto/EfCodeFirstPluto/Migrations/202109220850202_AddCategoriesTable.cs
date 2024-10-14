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
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            Sql("INSERT INTO Categories (NAME) VALUES('Web Developer')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Category");
        }
    }
}
