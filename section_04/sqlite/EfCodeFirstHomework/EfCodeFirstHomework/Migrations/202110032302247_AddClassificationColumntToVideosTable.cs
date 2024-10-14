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
            DropColumn("dbo.Videos", "ReleaseDate");
            DropColumn("dbo.Videos", "Classiﬁcation");
        }
    }
}
