using EfCodeFirstPluto.Model;

namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoryColumnFromCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo._Course",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Description = c.String(maxLength: 2147483647),
                        Level = c.Int(nullable: false),
                        FullPrice = c.Double(nullable: false, storeType: "real"),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            Sql("INSERT INTO _Course SELECT Id, Name, description, Level, FullPrice, Author_Id FROM Course");
            
            DropTable("dbo.Course");
            
            Sql("ALTER TABLE _Course RENAME TO Course");

        }
        
        public override void Down()
        {
            CreateTable(
                    "dbo._Course",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Description = c.String(maxLength: 2147483647),
                        Level = c.Int(nullable: false),
                        FullPrice = c.Double(nullable: false, storeType: "real"),
                        Author_Id = c.Int(),
                        Category_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id);
            
            AddForeignKey("dbo._Course", "Author_Id", "dbo.Author", "Id");
            AddForeignKey("dbo._Course", "Category_Id", "dbo.Categories", "Id");
            
            Sql("INSERT INTO _Course SELECT Id, Name, description, Level, FullPrice, Author_Id, '1' FROM Course");
            
            DropTable("dbo.Course");
            
            Sql("ALTER TABLE _Course RENAME TO Course");
        }
    }
}
