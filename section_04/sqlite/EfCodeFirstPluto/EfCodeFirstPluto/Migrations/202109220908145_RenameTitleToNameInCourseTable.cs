namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCourseTable : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Course RENAME COLUMN Title to Name");
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE Course RENAME COLUMN Name to Title");
        }
    }
}
