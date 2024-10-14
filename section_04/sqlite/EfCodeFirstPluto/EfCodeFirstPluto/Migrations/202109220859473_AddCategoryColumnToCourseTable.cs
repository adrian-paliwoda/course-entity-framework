namespace EfCodeFirstPluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColumnToCourseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Category_Id", c => c.Int());
            CreateIndex("dbo.Course", "Category_Id");
            AddForeignKey("dbo.Course", "Category_Id", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "Category_Id", "dbo.Category");
            DropIndex("dbo.Course", new[] { "Category_Id" });
            DropColumn("dbo.Course", "Category_Id");
        }
    }
}
