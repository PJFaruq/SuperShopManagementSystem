namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sales_And_SalesDetail_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SalesId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.SalesId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OutletId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                        CustomerName = c.String(nullable: false),
                        CustomerContact = c.String(),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Outlets", t => t.OutletId)
                .Index(t => t.OutletId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesDetails", "SalesId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Sales", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalesDetails", "ItemId", "dbo.Items");
            DropIndex("dbo.Sales", new[] { "EmployeeId" });
            DropIndex("dbo.Sales", new[] { "OutletId" });
            DropIndex("dbo.SalesDetails", new[] { "SalesId" });
            DropIndex("dbo.SalesDetails", new[] { "ItemId" });
            DropTable("dbo.Sales");
            DropTable("dbo.SalesDetails");
        }
    }
}
