namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_And_PurchaseDetail_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OutletId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PartyId = c.Int(nullable: false),
                        Remarks = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Outlets", t => t.OutletId)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .Index(t => t.OutletId)
                .Index(t => t.EmployeeId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Purchases", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Purchases", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Purchases", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.PurchaseDetails", new[] { "ItemId" });
            DropIndex("dbo.Purchases", new[] { "PartyId" });
            DropIndex("dbo.Purchases", new[] { "EmployeeId" });
            DropIndex("dbo.Purchases", new[] { "OutletId" });
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Purchases");
        }
    }
}
