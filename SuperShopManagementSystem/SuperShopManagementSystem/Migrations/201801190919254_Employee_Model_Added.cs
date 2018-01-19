namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        Image = c.Binary(),
                        ContactNo = c.String(),
                        Email = c.String(nullable: false),
                        EmergencyContactNo = c.String(),
                        NID = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        ReferenceId = c.Int(),
                        OutletId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ReferenceId)
                .ForeignKey("dbo.Outlets", t => t.OutletId, cascadeDelete: true)
                .Index(t => t.ReferenceId)
                .Index(t => t.OutletId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Employees", "ReferenceId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "OutletId" });
            DropIndex("dbo.Employees", new[] { "ReferenceId" });
            DropTable("dbo.Employees");
        }
    }
}
