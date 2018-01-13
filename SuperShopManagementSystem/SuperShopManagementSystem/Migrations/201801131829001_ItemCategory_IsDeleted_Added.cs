namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCategory_IsDeleted_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemCategories", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemCategories", "IsDeleted");
        }
    }
}
