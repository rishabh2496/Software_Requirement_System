namespace Software_Requirement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Software_Contract_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Software_ContractID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Software_Contract", t => t.Software_ContractID, cascadeDelete: true)
                .Index(t => t.Software_ContractID);
            
            CreateTable(
                "dbo.Software_Contract",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        OptionYears = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Software_Task_Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Software_ContractID = c.Int(nullable: false),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Software_Contract", t => t.Software_ContractID, cascadeDelete: true)
                .Index(t => t.Software_ContractID);
            
            CreateTable(
                "dbo.Software_Project",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Software_Task_OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Software_Task_Order", t => t.Software_Task_OrderID, cascadeDelete: true)
                .Index(t => t.Software_Task_OrderID);
            
            CreateTable(
                "dbo.Software_Project_Task",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Software_ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Software_Project", t => t.Software_ProjectID, cascadeDelete: true)
                .Index(t => t.Software_ProjectID);
            
            CreateTable(
                "dbo.Software_Task_Order_Labor_Cat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Software_Task_OrderID = c.Int(nullable: false),
                        LaborCategory = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Software_Task_Order", t => t.Software_Task_OrderID, cascadeDelete: true)
                .Index(t => t.Software_Task_OrderID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Software_Task_Order_Labor_Cat", "Software_Task_OrderID", "dbo.Software_Task_Order");
            DropForeignKey("dbo.Software_Project", "Software_Task_OrderID", "dbo.Software_Task_Order");
            DropForeignKey("dbo.Software_Project_Task", "Software_ProjectID", "dbo.Software_Project");
            DropForeignKey("dbo.Software_Task_Order", "Software_ContractID", "dbo.Software_Contract");
            DropForeignKey("dbo.Software_Contract_Category", "Software_ContractID", "dbo.Software_Contract");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Software_Task_Order_Labor_Cat", new[] { "Software_Task_OrderID" });
            DropIndex("dbo.Software_Project_Task", new[] { "Software_ProjectID" });
            DropIndex("dbo.Software_Project", new[] { "Software_Task_OrderID" });
            DropIndex("dbo.Software_Task_Order", new[] { "Software_ContractID" });
            DropIndex("dbo.Software_Contract_Category", new[] { "Software_ContractID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Software_Task_Order_Labor_Cat");
            DropTable("dbo.Software_Project_Task");
            DropTable("dbo.Software_Project");
            DropTable("dbo.Software_Task_Order");
            DropTable("dbo.Software_Contract");
            DropTable("dbo.Software_Contract_Category");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
