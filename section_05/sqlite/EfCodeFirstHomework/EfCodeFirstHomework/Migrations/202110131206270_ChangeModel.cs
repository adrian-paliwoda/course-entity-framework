using EfCodeFirstHomework.Model;

namespace EfCodeFirstHomework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo._Videos",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Int(nullable: false),
                        Classiﬁcation = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(v => v.GenreId);
            
            Sql("INSERT INTO _Videos (Id, Name, GenreId, Classiﬁcation, ReleaseDate) SELECT Id, Name, Genre_Id, Classiﬁcation, ReleaseDate FROM Videos");
            
            DropTable("dbo.Videos");
            Sql("ALTER TABLE _Videos RENAME TO Videos");
            
            
            CreateTable(
                    "dbo._Genres",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            
            Sql("INSERT INTO _Genres (Id, Name) SELECT Id, Name FROM Genres");
            DropTable("dbo.Genres");
            Sql("ALTER TABLE _Genres RENAME TO Genres");

            
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        VideoId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VideoId, t.TagId })
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.VideoId)
                .Index(t => t.TagId);
        }
        
        public override void Down()
        {
            CreateTable(
                    "dbo._Videos",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Genre_Id = c.Int(nullable: false),
                        Classiﬁcation = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .Index(p => p.Genre_Id);
            
            Sql("INSERT INTO _Videos (Id, Name, Genre_Id, Classiﬁcation, ReleaseDate) SELECT Id, Name, GenreId, Classiﬁcation, ReleaseDate FROM Videos");
            
            DropTable("dbo.Videos");
            Sql("ALTER TABLE _Videos RENAME TO Videos");
            
            
            CreateTable(
                    "dbo._Genres",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.Id);
            
            
            Sql("INSERT INTO _Genres (Id, Name) SELECT Id, Name FROM Genres");
            DropTable("dbo.Genres");
            Sql("ALTER TABLE _Genres RENAME TO Genres");
            
            DropTable("dbo.VideoTags");
            DropTable("dbo.Tags");
        }
    }
}
