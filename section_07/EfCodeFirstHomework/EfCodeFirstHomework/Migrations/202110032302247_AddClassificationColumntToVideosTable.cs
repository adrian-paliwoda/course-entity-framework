namespace EfCodeFirstHomework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassificationColumntToVideosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Classiﬁcation", c => c.Int(nullable: false));
            AddColumn("dbo.Videos", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
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
            
            Sql("INSERT INTO _Videos (Id, Name, Genre_Id) SELECT Id, Name, Genre_Id FROM Videos");
            
            DropTable("dbo.Videos");
            Sql("ALTER TABLE _Videos RENAME TO Videos");
        }
    }
}
