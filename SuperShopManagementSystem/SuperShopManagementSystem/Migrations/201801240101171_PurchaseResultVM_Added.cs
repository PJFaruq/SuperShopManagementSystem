namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseResultVM_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseResultVMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseNo = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        Supplier = c.String(),
                        Outlet = c.String(),
                        PurchaseBy = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PurchaseDetails", "PurchaseResultVM_Id", c => c.Int());
            CreateIndex("dbo.PurchaseDetails", "PurchaseResultVM_Id");
            AddForeignKey("dbo.PurchaseDetails", "PurchaseResultVM_Id", "dbo.PurchaseResultVMs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "PurchaseResultVM_Id", "dbo.PurchaseResultVMs");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseResultVM_Id" });
            DropColumn("dbo.PurchaseDetails", "PurchaseResultVM_Id");
            DropTable("dbo.PurchaseResultVMs");
        }
    }
}
