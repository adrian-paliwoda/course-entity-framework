namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTabels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 2147483647),
                        Description = c.String(maxLength: 2147483647),
                        Level = c.Int(nullable: false),
                        FullPrice = c.Double(nullable: false, storeType: "real"),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagCourse",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Course_Id })
                .ForeignKey("dbo.Tag", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagCourse", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.TagCourse", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.Course", "Author_Id", "dbo.Author");
            DropIndex("dbo.TagCourse", new[] { "Course_Id" });
            DropIndex("dbo.TagCourse", new[] { "Tag_Id" });
            DropIndex("dbo.Course", new[] { "Author_Id" });
            DropTable("dbo.TagCourse");
            DropTable("dbo.Tag");
            DropTable("dbo.Course");
            DropTable("dbo.Author");
        }
    }
}
