namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expense_And_ExpenseDetail_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OutletId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Due = c.Decimal(precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Outlets", t => t.OutletId)
                .Index(t => t.OutletId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ExpenseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reason = c.String(maxLength: 200),
                        ExpenseId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expenses", t => t.ExpenseId, cascadeDelete: true)
                .ForeignKey("dbo.ExpenseItems", t => t.ExpenseItemId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.ExpenseItemId)
                .Index(t => t.ExpenseId)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.ExpenseDetails", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ExpenseDetails", "ExpenseItemId", "dbo.ExpenseItems");
            DropForeignKey("dbo.ExpenseDetails", "ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ExpenseDetails", new[] { "Item_Id" });
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseId" });
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseItemId" });
            DropIndex("dbo.Expenses", new[] { "EmployeeId" });
            DropIndex("dbo.Expenses", new[] { "OutletId" });
            DropTable("dbo.ExpenseDetails");
            DropTable("dbo.Expenses");
        }
    }
}
