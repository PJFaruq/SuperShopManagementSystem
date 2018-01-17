namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expense_Category_And_Item_Addedd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false),
                        Description = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        IsDeleted = c.Boolean(nullable: false),
                        ExpenseCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId, cascadeDelete: true)
                .Index(t => t.ExpenseCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseItems", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropForeignKey("dbo.ExpenseCategories", "ParentId", "dbo.ExpenseCategories");
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.ExpenseCategories", new[] { "ParentId" });
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseCategories");
        }
    }
}
