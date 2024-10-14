using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGenreColumnInVideosTalbe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo._Videos",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Genre_Id = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true);
            
            Sql("INSERT INTO _Videos (Id, Name) SELECT Id, Name FROM Videos");
            
            DropTable("dbo.Videos");
            Sql("ALTER TABLE _Videos RENAME TO Videos");
            
            DropTable("dbo.VideoGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VideoGenres",
                c => new
                    {
                        Video_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_Id, t.Genre_Id })
                .ForeignKey("dbo.Videos", t => t.Video_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(t => t.Video_Id)
                .Index(t => t.Genre_Id);
            
           CreateTable(
                    "dbo._Videos",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            Sql("INSERT INTO _Videos (Id,Name) SELECT Id, Name FROM Videos");
            
            DropTable("dbo.Videos");
            Sql("ALTER TABLE _Videos RENAME TO Videos");
            
            DropTable("dbo.VideoGenres");
        }
    }
}
