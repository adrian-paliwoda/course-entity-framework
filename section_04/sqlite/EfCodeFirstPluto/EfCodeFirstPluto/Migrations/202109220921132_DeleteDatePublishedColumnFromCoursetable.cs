namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDatePublishedColumnFromCoursetable : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Course DROP COLUMN DataPublished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "DataPublished", c => c.DateTime());
        }
    }
}
