namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatePublishedInCourseTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "DatePublished", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "DatePublished", c => c.DateTime(nullable: false));
        }
    }
}
