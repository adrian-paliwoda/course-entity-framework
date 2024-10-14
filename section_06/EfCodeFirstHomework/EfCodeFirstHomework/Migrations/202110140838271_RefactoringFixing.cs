namespace EfCodeFirstHomework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringFixing : DbMigration
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
                        Classification = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true);

            Sql("INSERT INTO _Videos (Id, Name, GenreId, Classification, ReleaseDate) SELECT Id, Name, GenreId, Classiﬁcation, ReleaseDate FROM Videos");
            
            DropTable("dbo.Videos");
            Sql("ALTER TABLE _Videos RENAME TO Videos");
        }
        
        public override void Down()
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
            
            Sql("INSERT INTO _Videos (Id, Name, GenreId, Classiﬁcation, ReleaseDate) SELECT Id, Name, GenreId, Classification, ReleaseDate FROM Videos");
            
            DropTable("dbo.Videos");
            Sql("ALTER TABLE _Videos RENAME TO Videos");
        }
    }
}
