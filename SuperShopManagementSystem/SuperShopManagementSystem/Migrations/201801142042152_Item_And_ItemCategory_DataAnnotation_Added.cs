namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Item_And_ItemCategory_DataAnnotation_Added : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Image", c => c.Binary());
            AlterColumn("dbo.Items", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Description", c => c.String());
            AlterColumn("dbo.Items", "Image", c => c.Binary(nullable: false));
        }
    }
}
