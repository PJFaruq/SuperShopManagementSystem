namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDateFormat_Add_And_VM_Table_Deleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenseDetails", "ExpenseResultVM_Id", "dbo.ExpenseResultVMs");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseResultVM_Id", "dbo.PurchaseResultVMs");
            DropForeignKey("dbo.SalesDetails", "SalesReceipt_ViewModel_Id", "dbo.SalesReceipt_ViewModel");
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseResultVM_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseResultVM_Id" });
            DropIndex("dbo.SalesDetails", new[] { "SalesReceipt_ViewModel_Id" });
            DropColumn("dbo.ExpenseDetails", "ExpenseResultVM_Id");
            DropColumn("dbo.PurchaseDetails", "PurchaseResultVM_Id");
            DropColumn("dbo.SalesDetails", "SalesReceipt_ViewModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesDetails", "SalesReceipt_ViewModel_Id", c => c.Int());
            AddColumn("dbo.PurchaseDetails", "PurchaseResultVM_Id", c => c.Int());
            AddColumn("dbo.ExpenseDetails", "ExpenseResultVM_Id", c => c.Int());
            CreateIndex("dbo.SalesDetails", "SalesReceipt_ViewModel_Id");
            CreateIndex("dbo.PurchaseDetails", "PurchaseResultVM_Id");
            CreateIndex("dbo.ExpenseDetails", "ExpenseResultVM_Id");
            AddForeignKey("dbo.SalesDetails", "SalesReceipt_ViewModel_Id", "dbo.SalesReceipt_ViewModel", "Id");
            AddForeignKey("dbo.PurchaseDetails", "PurchaseResultVM_Id", "dbo.PurchaseResultVMs", "Id");
            AddForeignKey("dbo.ExpenseDetails", "ExpenseResultVM_Id", "dbo.ExpenseResultVMs", "Id");
        }
    }
}
