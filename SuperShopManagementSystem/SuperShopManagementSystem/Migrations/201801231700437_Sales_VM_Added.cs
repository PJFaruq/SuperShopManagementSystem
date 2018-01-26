namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sales_VM_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesReceipt_ViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalesNo = c.Int(nullable: false),
                        SalesDate = c.String(),
                        Outlet = c.String(),
                        SoldBy = c.String(),
                        CustomerName = c.String(),
                        ContactNo = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        GrandTotal = c.Double(nullable: false),
                        VAT = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SalesDetails", "SalesReceipt_ViewModel_Id", c => c.Int());
            CreateIndex("dbo.SalesDetails", "SalesReceipt_ViewModel_Id");
            AddForeignKey("dbo.SalesDetails", "SalesReceipt_ViewModel_Id", "dbo.SalesReceipt_ViewModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesDetails", "SalesReceipt_ViewModel_Id", "dbo.SalesReceipt_ViewModel");
            DropIndex("dbo.SalesDetails", new[] { "SalesReceipt_ViewModel_Id" });
            DropColumn("dbo.SalesDetails", "SalesReceipt_ViewModel_Id");
            DropTable("dbo.SalesReceipt_ViewModel");
        }
    }
}
