namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Relation_Between_Purchase_And_PurchaseDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseDetails", "PurchaseId");
            AddForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropColumn("dbo.PurchaseDetails", "PurchaseId");
        }
    }
}
