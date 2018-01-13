namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item_Category_Model_Added : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ItemCategories", new[] { "ParentId" });
            AlterColumn("dbo.ItemCategories", "ParentId", c => c.Int());
            CreateIndex("dbo.ItemCategories", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ItemCategories", new[] { "ParentId" });
            AlterColumn("dbo.ItemCategories", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemCategories", "ParentId");
        }
    }
}
