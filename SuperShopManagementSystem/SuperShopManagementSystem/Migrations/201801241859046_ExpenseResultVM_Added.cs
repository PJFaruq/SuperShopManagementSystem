namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseResultVM_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseResultVMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseNo = c.String(),
                        Outlet = c.String(),
                        Employee = c.String(),
                        Date = c.DateTime(nullable: false),
                        Due = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExpenseDetails", "ExpenseResultVM_Id", c => c.Int());
            CreateIndex("dbo.ExpenseDetails", "ExpenseResultVM_Id");
            AddForeignKey("dbo.ExpenseDetails", "ExpenseResultVM_Id", "dbo.ExpenseResultVMs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDetails", "ExpenseResultVM_Id", "dbo.ExpenseResultVMs");
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseResultVM_Id" });
            DropColumn("dbo.ExpenseDetails", "ExpenseResultVM_Id");
            DropTable("dbo.ExpenseResultVMs");
        }
    }
}
