namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization_And_Outlet_IsDeleted_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Outlets", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Outlets", "IsDeleted");
            DropColumn("dbo.Organizations", "IsDeleted");
        }
    }
}
