namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatePublishedColumnToCourseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "DataPublished", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "DataPublished");
        }
    }
}
